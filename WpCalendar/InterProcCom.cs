using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace InterProcCom
{
	partial class IPC
	{
		//コンストラクタ
		private IPC() { }
	}

	//アプリケーションのプロセスを取得する
	partial class IPC
	{
		//既に起動されている同じアプリを取得する
		//戻り値：	メインウインドウのハンドル
		//引数(out)：	目的のアプリのプロセスが格納される
		public static IntPtr GetAlreadyStartedApplication(out Process targetProc)
		{
			//目的のアプリのプロセスを取得する
			targetProc = GetAlreadyStartedProcess();
			if (targetProc == null) return IntPtr.Zero;

			//目的のアプリのForm.ShowInTaskbarがfalseだった場合（例：タスクトレイに格納するときfalseにした）、
			//Process.MainWindowHandleは0なので、Process.Idを手掛かりにウインドウ総当たりで検出する。
			IntPtr hWnd = targetProc.MainWindowHandle;
			if (hWnd == IntPtr.Zero)
				hWnd = IPC.GetWindowHandleByProcessId(targetProc.Id);
			return hWnd;
		}

		//既に起動中の同じアプリのプロセスを取得する
		private static Process GetAlreadyStartedProcess()
		{
			Process currentProc = Process.GetCurrentProcess();	//呼び出し元である自分自身
			Process[] procs = Process.GetProcessesByName(currentProc.ProcessName);	//戻り値にはcurrentProcも含まれる

			foreach (Process targetProc in procs)
			{
				//現在この関数を実行中である自分自身は判定対象から除く
				if (targetProc.Id == currentProc.Id)
				{
					continue;
				}

				//プロセスのフルパス名を比較して同じアプリであるか判定する
				if (string.Compare(targetProc.MainModule.FileName, currentProc.MainModule.FileName, true) == 0)
				{
					return targetProc;
				}
			}

			//起動中の同じアプリはない
			return null;
		}
	}
	
	//プロセスIDを指定してウインドウハンドルを取得する
	partial class IPC
	{
		//プロセスIDを指定してウインドウハンドルを取得する
		public static IntPtr GetWindowHandleByProcessId(int procId)
		{
			EnumWindowsCbParam tParam = new EnumWindowsCbParam();
			tParam.hWnd = IntPtr.Zero;
			tParam.ProcessId = procId;

			DlgtEnumWindowsProc dlgtEnumWindowsProc = EnumWindowsProc;
			EnumWindows(dlgtEnumWindowsProc, ref tParam);

			return tParam.hWnd;
		}

		//EnumWindows()のコールバック関数に渡す引数
		private struct EnumWindowsCbParam
		{
			public int ProcessId;
			public IntPtr hWnd;
		}

		//EnumWindows()のコールバック関数（検索処理の本体）
		//戻り値	true:列挙続行, false:列挙中止
		private static bool EnumWindowsProc(IntPtr hWnd, ref EnumWindowsCbParam lParam)
		{
			if (GetParent(hWnd) == IntPtr.Zero && IsWindowVisible(hWnd))
			{
				int procIdOfArgWnd;
				GetWindowThreadProcessId(hWnd, out procIdOfArgWnd);
				if (procIdOfArgWnd == lParam.ProcessId)
				{
					lParam.hWnd = hWnd;
					return false;
				}
			}
			return true;
		}

		#region API読み込みの定義

		[DllImport("user32.dll")]
		private extern static bool EnumWindows(DlgtEnumWindowsProc dlgtEnumWindowsProc, ref EnumWindowsCbParam lParam);
		private delegate bool DlgtEnumWindowsProc(IntPtr hWnd, ref EnumWindowsCbParam lParam);
		/*
		http://msdn.microsoft.com/ja-jp/library/cc410851.aspx
		BOOL EnumWindows(
		  WNDENUMPROC lpEnumFunc,  // コールバック関数
		  LPARAM lParam            // アプリケーション定義の値
		);
		
		http://msdn.microsoft.com/ja-jp/library/cc410833.aspx
		BOOL CALLBACK EnumWindowsProc(
		  HWND hwnd,      // 親ウィンドウのハンドル
		  LPARAM lParam   // アプリケーション定義の値
		);
		戻り値:	列挙を続行する場合は、0 以外の値（TRUE）を返してください。
				列挙を中止する場合は、0（FALSE）を返してください。
		*/

		[DllImport("user32.dll")]
		private extern static IntPtr GetParent(IntPtr hwnd);
		/*
		http://msdn.microsoft.com/ja-jp/library/cc364718.aspx
		戻り値:
			指定された子ウィンドウの親ウィンドウまたはオーナーウィンドウのハンドルを返します。
			指定したウィンドウがトップレベルのオーナーを持たないウィンドウだった場合、
			および関数が失敗した場合は NULL が返ります。
		*/

		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);
		/*
		http://msdn.microsoft.com/ja-jp/library/cc364819.aspx
		戻り値:
			Form.Hide()やForm.Visible=falseでないならtrue。
			タスクバー上にアイコン化されれていようと、タスクトレイに格納されていようと、
			他のウインドウの背面に隠れていようと、IsWindowVisible()の評価には関係ない。
		*/

		[DllImport("user32.dll")]
		private extern static int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
		/*
		http://msdn.microsoft.com/ja-jp/library/cc364779.aspx
		DWORD GetWindowThreadProcessId(
		  HWND hWnd,             // ウィンドウのハンドル
		  LPDWORD lpdwProcessId  // プロセス ID
		);
		引数:	lpdwProcessId
			プロセス ID を受け取る変数へのポインタを指定します。
			ポインタを指定すると、それが指す変数にプロセス ID がコピーされます。
			NULL を指定した場合は、プロセス ID の取得は行われません。
		戻り値:
			ウィンドウを作成したスレッドの ID が返ります。
		*/

		#endregion
	}

	//SendMessageを使って起動済みアプリケーションに文字列を渡す
	partial class IPC
	{
		//SendMessageを使ってプロセス間通信で文字列を渡す
		public static void SendString(IntPtr targetWindowHandle, string str)
		{
			COPYDATASTRUCT cds = new COPYDATASTRUCT();
			cds.dwData = IntPtr.Zero;
			cds.lpData = str;
			cds.cbData = str.Length * sizeof(char);
			//受信側ではlpDataの文字列を(cbData/2)の長さでstring.Substring()する

			IntPtr myWindowHandle = Process.GetCurrentProcess().MainWindowHandle;
			SendMessage(targetWindowHandle, WM_COPYDATA, myWindowHandle, ref cds);
		}

		//SendString()で送信された文字列を取り出す
		//・該当するメッセージを受信したWindProc()でこのメソッドを呼び出す。
		public static string ReceiveString(System.Windows.Forms.Message m)
		{
			string str;
			try
			{
				COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
				str = cds.lpData;
				str = str.Substring(0, cds.cbData / 2);
			}
			catch { str = null; }
			return str;
		}

		#region API読み込みの定義

		//SendMessage（一般）
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
		public const int WM_APP = 0x8000;	//0xBFFFまで
		/*
		http://msdn.microsoft.com/ja-jp/library/cc411022.aspx
		LRESULT SendMessage(
		  HWND hWnd,      // 送信先ウィンドウのハンドル
		  UINT Msg,       // メッセージ
		  WPARAM wParam,  // メッセージの最初のパラメータ
		  LPARAM lParam   // メッセージの 2 番目のパラメータ
		);
		SendMessage()は同期処理。PostMessage()は非同期処理。
		*/

		//SendMessage（データ転送）
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
		public const int WM_COPYDATA = 0x004A;

		#endregion
	}

	//SendMessageで送る構造体（Unicode文字列送信に最適化したパターン）
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	struct COPYDATASTRUCT
	{
		public IntPtr dwData;
		public int cbData;
		[MarshalAs(UnmanagedType.LPWStr)]
		public string lpData;
	}
	/*
	http://msdn.microsoft.com/ja-jp/library/ms649010(v=VS.80).aspx
	typedef struct tagCOPYDATASTRUCT {
	  ULONG_PTR dwData;
	  DWORD     cbData;
	  PVOID     lpData;
	} COPYDATASTRUCT, *PCOPYDATASTRUCT;

	文字列のマーシャリングについて
	http://msdn.microsoft.com/ja-jp/library/s9ts558h(v=vs.90).aspx
	*/

}	//namespace
