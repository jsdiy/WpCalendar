using InterProcCom;
using System;
using System.Diagnostics;   //Process,Debug
using System.Threading;     //Mutex
using System.Windows.Forms;

namespace WpCalendar
{
	static class Program
	{
		public static FmMain MainForm { get; private set; }

		public static string AppVer { get; private set; } =
			//"ver. 1.30";	//2019/11/06	令和対応
			//"ver. 1.40";	//2023/11/14	スタートアップ登録機能を廃止
			"ver. 2.00";	//2025/12/14	保存データをxml形式に変更／常駐機能廃止／構造見直し（ほぼ全クラス改造）

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			//ミューテックスを生成し、多重起動チェックする
			Mutex mutexObj = null;
			bool isMultiBoot = false;
			try
			{
				mutexObj = new Mutex(false, AppVer + "WpCalendar_4vj0htc4ont3e3two132hmhjma60kb3k10s7i5ncbqcccvl1qj6y08t68aahldnm");
				isMultiBoot = !mutexObj.WaitOne(0, false);	//ミューテックスからシグナルを受信できなかったら多重起動である
			}
			catch { }

			if (isMultiBoot)
			{
				//起動済みアプリを呼び出す
				Process targetProc;
				IntPtr handle = IPC.GetAlreadyStartedApplication(out targetProc);
				//IPC.PrintFile("target handle=" + handle);
				if (handle != IntPtr.Zero)
				{
					//引数なしの場合、アプリを最前面に呼び出す（タスクトレイにいたら出す）
					//引数ありの場合、それを渡して呼び出す（ウインドウ表示状態はそのまま。タスクトレイにいても出さない）
					string[] args = Environment.GetCommandLineArgs();	//args[0]はアプリ自身(exe)のフルパス
					if (args.Length <= 1)
						IPC.SendMessage(handle, IPC.WM_APP + 1, IntPtr.Zero, IntPtr.Zero);
					else
						IPC.SendString(handle, string.Join("\t", args));
					//IPC.PrintFile("SendMessage/SendString ok");

					#region ここで取得したハンドルを継続して利用する場合の注意
					/*
					・C#(.NetFramework)の仕様上、アプリをタスクトレイに出し入れするとき（Form.ShowInTaskbarが変化するとき）、ウインドウハンドルが変化する。
						以降の処理でウインドウハンドルを利用する場合、このタイミングで取得し直す必要がある。
					・Process.Idは変化しない。
					・タスクトレイから出した場合(Form.ShowInTaskbar=true)、Process.GetProcessById()経由で取得すればよい。
						タスクトレイに入れた場合(同=false)、Win32ApiUty.GetWindowHandleByProcessId()で検出する。
					
					タスクトレイから出した後の例：
					targetProc = Process.GetProcessById(targetProc.Id);	//Processを取得し直す
					handle = (targetProc == null) ? IntPtr.Zero : targetProc.MainWindowHandle;
					*/
					#endregion
				}
			}
			else
			{
				//通常の起動
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				MainForm = new FmMain();
				Application.Run(MainForm);	//ブロッキングされる。Formをクローズするまで次の行は処理されない

				//ミューテックスを解放／破棄する
				if (mutexObj != null)
				{
					mutexObj.ReleaseMutex();
					mutexObj.Close();
				}
			}
		}
	}
}
