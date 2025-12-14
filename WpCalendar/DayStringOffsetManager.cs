using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms; //TextRenderer

namespace WpCalendar
{
	class DayStringOffsetManager
	{
		private struct DrawInfo
		{
			public string day;
			public Rectangle rect;
		}

		public Rectangle CellRect { get; set; }
		public Point StrOffset { get; set; }

		private readonly Color cellColor, strColor;
		private readonly DrawInfo[] drawInfos;

		//コンストラクタ
		public DayStringOffsetManager()
		{
			cellColor = Color.FromArgb(Int32.Parse("FFFFDC00", NumberStyles.HexNumber));
			strColor = Color.Black;

			int[] intDays = { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 30 };
			drawInfos = new DrawInfo[intDays.Length];
			for (int i = 0; i < intDays.Length; i++) { drawInfos[i].day = intDays[i].ToString(); }
		}

		//日にちの文字列の最大サイズ（余白を含む）を更新する	※プロパティを更新する
		public Size GetMaxDayCellSize(Font font)
		{
			Size proposedSize = new Size(int.MaxValue, int.MaxValue);
			Size cellMax = new Size(0, 0);
			for (int i = 0; i < drawInfos.Length; i++)
			{
				Size renderSize = TextRenderer.MeasureText(drawInfos[i].day, font,
					proposedSize, TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
				drawInfos[i].rect.Size = renderSize;

				cellMax.Width = Math.Max(cellMax.Width, renderSize.Width);
				cellMax.Height = Math.Max(cellMax.Height, renderSize.Height);
			}
			return cellMax;
		}

		//親サイズに対して子サイズを中央揃えにする
		//戻り値：	親領域の左上を起点とした子領域の位置（とサイズ）
		public Rectangle GetCenteringRect(Size parentSize, Size childSize)
		{
			Point point = new Point();
			point.X = (parentSize.Width - childSize.Width) / 2;
			point.Y = (parentSize.Height - childSize.Height) / 2;
			return new Rectangle(point, childSize);
		}

		//マス目を塗りつぶす
		public void	FillCellRect(Graphics g, Rectangle rect)
		{
			using (var brush = new SolidBrush(cellColor))
			{
				g.FillRectangle(brush, rect);
			}
		}

		//日にちの数字（全バリエーション）を描画する
		//・マス目に対してセンタリングし、その状態に対してユーザー指定の調整値を加える。
		public void DrawDayString(Graphics g, Font font, Rectangle cellRect, Point strOffset)
		{
			using (var brush = new SolidBrush(strColor))
			{
				for (int i = 0; i < drawInfos.Length; i++)
				{
					ref DrawInfo info = ref drawInfos[i];   //読み替え
					Rectangle strRect = GetCenteringRect(cellRect.Size, info.rect.Size);
					strRect.Offset(cellRect.Location);
					strRect.Offset(strOffset);
					g.DrawString(info.day, font, brush, strRect.Location);
				}
			}
		}

}   //class
}	//namespace
