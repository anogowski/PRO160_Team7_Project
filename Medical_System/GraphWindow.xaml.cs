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

namespace Medical_System {
	public partial class GraphWindow : Window {
		/// <summary>
		/// Graphs a given an Enumerable collection of NUMERIC datatypes
		/// </summary>
		/// <typeparam name="T">
		/// Ensure T is a NUMERIC datatype, do not pass in strings, characters, etc.
		/// </typeparam>
		/// <param name="axisY">
		/// The Enumerable collection of data you wish to lie along the Y axis.
		/// The X axis is the amount of elements in the list.
		/// </param>
		public void GraphData<T>(IEnumerable<T> axisY) where T : IComparable<T> {
			dynamic maxY = getMax(axisY);
			dynamic minY = getMin(axisY);
			int maxX = axisY.Count() - 1;
			dynamic horizonHeight = Canvas_graph.Height + (minY / (maxY - minY)) * Canvas_graph.Height;
			float textPosition_x = (float)(Canvas_y_axis.Width / 2 - 5);

			drawHorizontalLine((float)horizonHeight, 2, Colors.Black);
			drawText_yAxis(textPosition_x, (float)horizonHeight, (float)horizonHeight, "0", ref Canvas_y_axis);

			for(int i = (int)minY; i <= maxY; i++) {
				dynamic y = Canvas_graph.Height - ((i - minY) / (maxY - minY)) * Canvas_graph.Height;

				drawText_yAxis(textPosition_x, (float)y, (float)horizonHeight, i.ToString(), ref Canvas_y_axis);
				drawHorizontalLine((float)y, 0.5f, Colors.Gray);
			}

			for(int i = 0; i <= maxX; i += ((int)maxX / 10)) {
				dynamic x = ((float)i / (float)maxX) * Canvas_graph.Width;

				drawText_xAxis((float)x, (float)Canvas_x_axis.Height / 2, (float)maxX, i.ToString(), ref Canvas_x_axis);
				drawVerticalLine((float)x, 0.5f, Colors.Gray);
			}

			for(int i = 0; i < maxX; i++) {
				dynamic point1_x = ((float)i / (float)maxX) * Canvas_graph.Width;
				dynamic point2_x = ((float)(i + 1) / (float)maxX) * Canvas_graph.Width;
				dynamic point1_y = Canvas_graph.Height - ((axisY.ElementAt(i) - minY) / (maxY - minY)) * Canvas_graph.Height;
				dynamic point2_y = Canvas_graph.Height - ((axisY.ElementAt(i + 1) - minY) / (maxY - minY)) * Canvas_graph.Height;

				double theNumber = (double)((dynamic)axisY.ElementAt(i));

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

		private void drawText_yAxis(float x, float y, float horizon_y, string text, ref Canvas canvas) {
			TextBlock textBlock = new TextBlock();

			float yOffset = (y > horizon_y) ? 15 : (y < horizon_y) ? 0 : 7.5f;

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
