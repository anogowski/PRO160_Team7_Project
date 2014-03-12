using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Medical_System {
	public partial class GraphWindow : Window {
		private Timer timer;
		private float graphScale;
		private delegate void graph<T>(IEnumerable<T> data);

		/// <summary>
		/// Graphs a given Enumerable collection of NUMERIC datatypes
		/// </summary>
		/// <typeparam name="T">
		/// Ensure T is a NUMERIC datatype, do not pass in strings, characters, etc.
		/// </typeparam>
		/// <param name="axisY">
		/// The Enumerable collection of data you wish to lie along the Y axis.
		/// The X axis is the amount of elements in the list.
		/// </param>
		private void GraphData<T>(IEnumerable<T> axisY, float scale) where T : IComparable<T> {
			dynamic yMax = getMax(axisY);
			dynamic yMin = getMin(axisY);
			int xMax = axisY.Count() - 1;
			dynamic horizonY = Canvas_graph.Height + (yMin / (yMax - yMin)) * Canvas_graph.Height;
			float textPosition_x = (float)(Canvas_y_axis.Width / 2 - 5);

			drawHorizontalLine((float)horizonY, 2, Colors.Black);
			drawText_yAxis(textPosition_x, (float)horizonY, (float)horizonY, "0", ref Canvas_y_axis);

			for(int i = (int)yMin; i <= yMax; i++) {
				dynamic y = Canvas_graph.Height - ((i - yMin) / (yMax - yMin)) * Canvas_graph.Height;

				drawText_yAxis(textPosition_x, (float)y, (float)horizonY, i.ToString(), ref Canvas_y_axis);
				drawHorizontalLine((float)y, 0.5f, Colors.Gray);
			}

			int amountOfVerticalLines = ((int)xMax >= 10) ? 10 : (int)xMax;

			for(int i = 0; i <= xMax; i += ((int)xMax / amountOfVerticalLines)) {
				dynamic x = ((float)i / (float)xMax) * Canvas_graph.Width;

				drawText_xAxis((float)x, (float)Canvas_x_axis.Height / 2, (float)xMax, i.ToString(), ref Canvas_x_axis);
				drawVerticalLine((float)x, 0.5f, Colors.Gray);
			}

			for(int i = 0; i < xMax; i++) {
				dynamic point1_x = ((float)i / (float)xMax) * Canvas_graph.Width;
				dynamic point2_x = ((float)(i + 1) / (float)xMax) * Canvas_graph.Width;
				dynamic point1_y = Canvas_graph.Height - ((((dynamic)axisY.ElementAt(i) * scale) - yMin) / (yMax - yMin)) * Canvas_graph.Height;
				dynamic point2_y = Canvas_graph.Height - ((((dynamic)axisY.ElementAt(i + 1) * scale) - yMin) / (yMax - yMin)) * Canvas_graph.Height;

				Line line = new Line();
				line.Stroke = Brushes.Navy;
				line.StrokeThickness = 1;

				line.X1 = point1_x;
				line.X2 = point2_x;
				line.Y1 = point1_y;
				line.Y2 = point2_y;

				Canvas_graph.Children.Add(line);
			}
		}

		private void startTimer<T>(IEnumerable<T> data) where T : IComparable<T> {
			timer = new Timer();
			timer.Tick += new EventHandler((sender, e) => timer_tick(sender, e, data));
			timer.Interval = 10;
			timer.Start();
		}

		public void GraphData<T>(IEnumerable<T> axisY) where T : IComparable<T> {
			startTimer(axisY);
		}

		private void timer_tick<T>(object sender, EventArgs e, IEnumerable<T> data) where T : IComparable<T> {
			timer.Interval = 20 - (int)(10 * Math.Sin(graphScale * 180 * 0.0174532925f));

			if(graphScale < 1) {
				graphScale += 0.015f;

				if(graphScale > 1) {
					graphScale = 1;
				}

				Canvas_graph.Children.Clear();
				Canvas_x_axis.Children.Clear();
				Canvas_y_axis.Children.Clear();
				GraphData(data, graphScale);
			} else {
				timer.Stop();
			}
		}

		private T getMin<T>(IEnumerable<T> values) where T : IComparable<T> {
			T result = default(T);

			foreach(T value in values) {
				if(value.CompareTo(result) < 0) {
					result = value;
				}
			}

			return result;
		}

		private T getMax<T>(IEnumerable<T> values) where T : IComparable<T> {
			T result = default(T);

			foreach(T value in values) {
				if(value.CompareTo(result) > 0) {
					result = value;
				}
			}

			return result;
		}

		private void drawVerticalLine(float x, float thickness, Color color) {
			Line line = new Line();
			line.Stroke = new SolidColorBrush(color);
			line.StrokeThickness = thickness;

			line.X1 = x;
			line.X2 = x;
			line.Y1 = 0;
			line.Y2 = Canvas_graph.Height;

			Canvas_graph.Children.Add(line);
		}

		private void drawHorizontalLine(float y, float thickness, Color color) {
			Line line = new Line();
			line.Stroke = new SolidColorBrush(color);
			line.StrokeThickness = thickness;

			line.X1 = 0;
			line.X2 = Canvas_graph.Width;
			line.Y1 = y;
			line.Y2 = y;

			Canvas_graph.Children.Add(line);
		}

		private void drawText_xAxis(float x, float y, float xMax, string text, ref Canvas canvas) {
			TextBlock textBlock = new TextBlock();

			textBlock.Text = text;
			textBlock.Foreground = new SolidColorBrush(Colors.Black);
			Canvas.SetLeft(textBlock, x);
			Canvas.SetTop(textBlock, y - 7.5f);
			canvas.Children.Add(textBlock);
		}

		private void drawText_yAxis(float x, float y, float horizonY, string text, ref Canvas canvas) {
			TextBlock textBlock = new TextBlock();

			float yOffset = (y > horizonY) ? 15 : (y < horizonY) ? 0 : 7.5f;

			textBlock.Text = text;
			textBlock.Foreground = new SolidColorBrush(Colors.Black);
			Canvas.SetLeft(textBlock, x);
			Canvas.SetTop(textBlock, y - yOffset);
			canvas.Children.Add(textBlock);
		}

		public GraphWindow() {
			InitializeComponent();

			Canvas_graph.Height = 500 * 0.9f;
			Canvas_graph.Width = 500 * 0.9f;

			Canvas_y_axis.Height = 500 * 0.9f;
			Canvas_y_axis.Width = 500 * 0.1f;

			Canvas_x_axis.Height = 500 * 0.1f;
			Canvas_x_axis.Width = 500 * 0.9f;
		}
	}
}
