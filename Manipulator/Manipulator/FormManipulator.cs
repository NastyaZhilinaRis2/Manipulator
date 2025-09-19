using System.Net.Sockets;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;
using static Manipulator.FormManipulator;

namespace Manipulator
{
    public partial class FormManipulator : Form
    {
        public delegate float[,] TransformationMatrixDelegate(float param1, float param2);
        Pen pen;

        int widthMainContainer;
        int heightMainContainer;

        private List<object> figureAllElements = new List<object>();
        private List<object> figureRotationElements = new List<object>();
        private List<object> figureRotation2Elements = new List<object>();
        private List<object> figureExtendableElements = new List<object>();
        private List<object> figureExtendable2Elements = new List<object>();

        ScrollBar scrollBar;

        public FormManipulator()
        {
            InitializeComponent();
            InitializePanel();
            scrollBar = new ScrollBar();
            InitializeFigure();
        }
        private void InitializePanel()
        {
            pen = new Pen(Color.Black, 5);

            MainContainer.IsSplitterFixed = true;

            widthMainContainer = MainContainer.Panel2.ClientSize.Width;
            heightMainContainer = MainContainer.Panel2.ClientSize.Height;
        }
        public class ScrollBar
        {
            private int CurrentScrollWheels, CurrentScrollExtendable, CurrentScrollRotation, CurrentScrollExtendable2, CurrentScrollRotation2;
            public ScrollBar()
            {
                CurrentScrollWheels = 0;
                CurrentScrollExtendable = 0;
                CurrentScrollRotation = 0;
                CurrentScrollExtendable2 = 0;
                CurrentScrollRotation2 = 0;
            }
            public int GetCurrentScrollBar(string nameScroll)
            {
                switch (nameScroll)
                {
                    case "trackBarWheels":
                        return this.CurrentScrollWheels;
                    case "trackBarExtendable":
                        return this.CurrentScrollExtendable;
                    case "trackBarRotation":
                        return this.CurrentScrollRotation;
                    case "trackBarExtendable2":
                        return this.CurrentScrollExtendable2;
                    case "trackBarRotation2":
                        return this.CurrentScrollRotation2;
                    default:
                        return 0;
                }
            }
            public void SetCurrentScrollBar(string nameScroll, int NewValue)
            {
                switch (nameScroll)
                {
                    case "trackBarWheels":
                        CurrentScrollWheels = (int)NewValue; break;
                    case "trackBarExtendable":
                        CurrentScrollExtendable = (int)NewValue; break;
                    case "trackBarRotation":
                        CurrentScrollRotation = (int)NewValue; break;
                    case "trackBarExtendable2":
                        CurrentScrollExtendable2 = (int)NewValue; break;
                    case "trackBarRotation2":
                        CurrentScrollRotation2 = (int)NewValue; break;
                    default:
                        break;
                }
            }
        }
        private void InitializeFigure()
        {
            figureAllElements.Clear();
            float sizeBasePlatform = 150;

            Line basePlatform = new Line(0, 100, sizeBasePlatform, 100);

            float wheelRadius = sizeBasePlatform / 10f;
            float wheelY = basePlatform.PointStart.Y - wheelRadius;

            Ñircle[] Wheels = new Ñircle[2] {
                new Ñircle(sizeBasePlatform / 4, wheelY, wheelRadius),
                new Ñircle(sizeBasePlatform / 4 * 3, wheelY, wheelRadius)
            };
            Line Extendable = new Line(sizeBasePlatform / 2, basePlatform.PointStart.Y, sizeBasePlatform / 2, basePlatform.PointStart.Y + 50);
            Line Connector = new Line(Extendable.PointEnd.X, Extendable.PointEnd.Y, Extendable.PointEnd.X + 50, Extendable.PointEnd.Y + 40);
            Line Extendable2 = new Line(Connector.PointEnd.X, Connector.PointEnd.Y, Connector.PointEnd.X + 40, Connector.PointEnd.Y - 30);

            Line[] Bucket = new Line[3];
            Bucket[0] = new Line(Extendable2.PointEnd.X - 10, Extendable2.PointEnd.Y - 10, Extendable2.PointEnd.X + 10, Extendable2.PointEnd.Y + 10);
            Bucket[1] = new Line(Bucket[0].PointStart.X, Bucket[0].PointStart.Y, Bucket[0].PointStart.X + 15, Bucket[0].PointStart.Y - 15);
            Bucket[2] = new Line(Bucket[0].PointEnd.X, Bucket[0].PointEnd.Y, Bucket[0].PointEnd.X + 15, Bucket[0].PointEnd.Y - 15);

            Ñircle Rotation = new Ñircle(Connector.PointStart.X, Connector.PointStart.Y, 5);
            Ñircle Rotation2 = new Ñircle(Connector.PointEnd.X, Connector.PointEnd.Y, 5);

            figureAllElements.Add(basePlatform);
            figureAllElements.AddRange(Wheels);
            figureAllElements.Add(Extendable);
            figureAllElements.Add(Connector);
            figureAllElements.Add(Extendable2);
            figureAllElements.AddRange(Bucket);
            figureAllElements.Add(Rotation);
            figureAllElements.Add(Rotation2);

            figureRotationElements.Add(Rotation);
            figureRotationElements.Add(Connector);
            figureRotationElements.Add(Extendable2);
            figureRotationElements.AddRange(Bucket);
            figureRotationElements.Add(Rotation2);

            figureRotation2Elements.Add(Rotation2);
            figureRotation2Elements.Add(Extendable2);
            figureRotation2Elements.AddRange(Bucket);

            figureExtendableElements.Add(Extendable);
            figureExtendableElements.Add(Connector);
            figureExtendableElements.Add(Extendable2);
            figureExtendableElements.AddRange(Bucket);
            figureExtendableElements.Add(Rotation);
            figureExtendableElements.Add(Rotation2);


            figureExtendable2Elements.Add(Extendable2);
            figureExtendable2Elements.AddRange(Bucket);

            trackBarWheels.Maximum = (int)(widthMainContainer - Bucket[2].PointEnd.X);// íà ñêîëüêî ìàêñèìàëüíî ìîæíî ïåðåäâèãàòü ôèãóðêó
        }
        public class Ñircle
        {
            public PointF Centre { get; private set; }
            public float Radius { get; private set; }
            public float Diameter { get; private set; }
            public float[,] MatrixData { get; private set; }
            public Ñircle(float x, float y, float r)
            {
                Centre = new PointF(x, y);
                Radius = r;
                Diameter = r * 2;
                MatrixData = new float[1, 3] { { Centre.X, Centre.Y, 1 } };
            }
            public void NewMatrixData(float[,] newMatrixData)
            {
                MatrixData = newMatrixData;
                Centre = new PointF(newMatrixData[0, 0], newMatrixData[0, 1]);
            }
        }
        public class Line
        {
            public PointF PointStart { get; private set; }
            public PointF PointEnd { get; private set; }
            public float[,] MatrixData { get; private set; }
            public Line(float x1, float y1, float x2, float y2)
            {
                PointStart = new PointF(x1, y1);
                PointEnd = new PointF(x2, y2);

                MatrixData = new float[2, 3] {
                    { PointStart.X, PointStart.Y, 1 },
                    { PointEnd.X, PointEnd.Y, 1 }
                };
            }
            public void NewMatrixData(float[,] newMatrixData)
            {
                MatrixData = newMatrixData;
                PointStart = new PointF(newMatrixData[0, 0], newMatrixData[0, 1]);
                PointEnd = new PointF(newMatrixData[1, 0], newMatrixData[1, 1]);
            }
        }
        public static class MatrixOps
        {
            static public float[,] Transfer(float m, float n)
            {
                float[,] matrTransfer = new float[3, 3] {
                    { 1, 0, 0 },
                    { 0, 1, 0 },
                    { m, n, 1 }
                };
                return matrTransfer;
            }
            static public float[,] Rotation(float a, float b)
            {
                float angleDegrees = a;
                float rad = (float)(angleDegrees * Math.PI / 180f);

                float[,] matrRotation = new float[3, 3] {
                    { (float)Math.Cos(rad), (float)Math.Sin(rad), 0 },
                    { (float)-Math.Sin(rad), (float)Math.Cos(rad), 0 },
                    { 0, 0, 1 }
                };
                return matrRotation;
            }
            static public float[,] Scaling(float a, float d)
            {
                float[,] matrScaling = new float[3, 3] {
                    { a, 0, 0 },
                    { 0, d, 0 },
                    { 0, 0, 1 }
                };
                return matrScaling;
            }
            static public float[,] Transformation(float[,] data, TransformationMatrixDelegate transformationMatrixDelegate, float param1, float param2)
            {
                float[,] matrTransformation = transformationMatrixDelegate(param1, param2);

                int rowsData = data.GetLength(0);
                int colsData = data.GetLength(1);
                int rowsTrans = matrTransformation.GetLength(0);
                int colsTrans = matrTransformation.GetLength(1);

                if (colsData != rowsTrans)
                    throw new ArgumentException("Ìàòðèöû íåñîâìåñòèìû äëÿ óìíîæåíèÿ");

                float[,] finallData = new float[rowsData, colsTrans];

                for (int iData = 0; iData < rowsData; iData++)
                {
                    for (int jTrans = 0; jTrans < colsTrans; jTrans++)
                    {
                        float sum = 0;
                        for (int jDataiMatr = 0; jDataiMatr < colsData; jDataiMatr++)
                        {
                            sum += data[iData, jDataiMatr] * matrTransformation[jDataiMatr, jTrans];
                        }
                        finallData[iData, jTrans] = sum;
                    }
                }
                return finallData;
            }
        }
        public static class FigureRenderer
        {
            public static void Render(Graphics g, Pen pen, object element, int screenHeight)
            {
                if (element is Line line)
                    g.DrawLine(pen, line.PointStart.X, screenHeight - line.PointStart.Y,
                                     line.PointEnd.X, screenHeight - line.PointEnd.Y);
                else if (element is Ñircle circle)
                    g.DrawEllipse(pen, circle.Centre.X - circle.Diameter / 2,
                                   screenHeight - (circle.Centre.Y + circle.Diameter / 2),
                                   circle.Diameter, circle.Diameter);
            }
        }
        private void MainContainer_Panel2_Paint(object sender, PaintEventArgs e)
        {
            foreach (var element in figureAllElements)
            {
                FigureRenderer.Render(e.Graphics, pen, element, heightMainContainer);
            }
        }
        private (float transferX, float transferY) GetScrollValues(TrackBar newScroll, int currentScroll, bool isIncreaseIn)
        {
            scrollBar.SetCurrentScrollBar(newScroll.Name, newScroll.Value);
            int newScrollValue = newScroll.Value - currentScroll;
            return isIncreaseIn ? (newScrollValue > 0 ? (2f, 2f) : (0.5f, 0.5f)) : (newScrollValue, 0f);
        }
        private void ApplyActionsRelativeOriginToElement(object element, float BasePointX, float BasePointY, float transferX, float transferY, TransformationMatrixDelegate action)
        {
            if (element is Line line)
            {
                line.NewMatrixData(MatrixOps.Transformation(line.MatrixData, MatrixOps.Transfer, -BasePointX, -BasePointY));
                line.NewMatrixData(MatrixOps.Transformation(line.MatrixData, action, transferX, transferX));
                line.NewMatrixData(MatrixOps.Transformation(line.MatrixData, MatrixOps.Transfer, BasePointX, BasePointY));
            }
            else
            {
                if (element is Ñircle circle)
                {
                    circle.NewMatrixData(MatrixOps.Transformation(circle.MatrixData, MatrixOps.Transfer, -BasePointX, -BasePointY));
                    circle.NewMatrixData(MatrixOps.Transformation(circle.MatrixData, action, transferX, transferX));
                    circle.NewMatrixData(MatrixOps.Transformation(circle.MatrixData, MatrixOps.Transfer, BasePointX, BasePointY));
                }
            }
        }
        private void ApplyScalingToElements(List<object> elements, float transferX, float transferY)
        {
            float previousX, previousY, newX, newY;

            float BasePointX, BasePointY;
            if (elements[0] is Line line)
            {
                BasePointX = line.PointStart.X;
                BasePointY = line.PointStart.Y;

                previousX = line.PointEnd.X;
                previousY = line.PointEnd.Y;

                ApplyActionsRelativeOriginToElement(line, BasePointX, BasePointY, transferX, transferY, MatrixOps.Scaling);

                newX = line.PointEnd.X;
                newY = line.PointEnd.Y;
            }
            else
                throw new ArgumentException("Îøèáêà â ApplyScalingToElements");

            transferX = newX - previousX;
            transferY = newY - previousY;

            ApplyTransferToElements(elements, transferX, transferY, true);
        }
        private void ApplyRotationToElements(List<object> elements, float transferX, float transferY)
        {
            float BasePointX, BasePointY;

            if (elements[0] is Ñircle c)
            {
                BasePointX = c.Centre.X;
                BasePointY = c.Centre.Y;
            }
            else
                throw new ArgumentException("Îøèáêà â ApplyRotationToElements");
            foreach (var element in elements)
            {
                ApplyActionsRelativeOriginToElement(element, BasePointX, BasePointY, transferX, transferY, MatrixOps.Rotation);
            }
        }
        private void ApplyTransferToElements(List<object> elements, float transferX, float transferY, bool skipFirst = false)
        {
            var elementsToProcess = skipFirst ? elements.Skip(1) : elements;

            foreach (var element in elementsToProcess)
            {
                if (element is Line line)
                {
                    line.NewMatrixData(MatrixOps.Transformation(line.MatrixData, MatrixOps.Transfer, transferX, transferY));
                }
                else if (element is Ñircle circle)
                {
                    circle.NewMatrixData(MatrixOps.Transformation(circle.MatrixData, MatrixOps.Transfer, transferX, transferY));
                }
            }
        }
        private void trackBarWheels_Scroll(object sender, EventArgs e)
        {
            TrackBar newScroll = (TrackBar)sender;

            float transferX, transferY;
            int currentScroll = scrollBar.GetCurrentScrollBar(newScroll.Name);

            (transferX, transferY) = GetScrollValues(newScroll, currentScroll, false);

            ApplyTransferToElements(figureAllElements, transferX, transferY);

            MainContainer.Panel2.Refresh();

        }
        private void trackBarExtendable_Scroll(object sender, EventArgs e)
        {
            TrackBar newScroll = (TrackBar)sender;

            float transferX, transferY;
            int currentScroll = scrollBar.GetCurrentScrollBar(newScroll.Name);

            (transferX, transferY) = GetScrollValues(newScroll, currentScroll, true);

            ApplyScalingToElements(figureExtendableElements, transferX, transferY);

            MainContainer.Panel2.Refresh();
        }
        private void trackBarRotation_Scroll(object sender, EventArgs e)
        {
            TrackBar newScroll = (TrackBar)sender;

            float transferX, transferY;
            int currentScroll = scrollBar.GetCurrentScrollBar(newScroll.Name);

            (transferX, transferY) = GetScrollValues(newScroll, currentScroll, false);

            ApplyRotationToElements(figureRotationElements, transferX, transferY);

            MainContainer.Panel2.Refresh();
        }
        private void trackBarRotation2_Scroll(object sender, EventArgs e)
        {
            TrackBar newScroll = (TrackBar)sender;

            float transferX, transferY;
            int currentScroll = scrollBar.GetCurrentScrollBar(newScroll.Name);

            (transferX, transferY) = GetScrollValues(newScroll, currentScroll, false);

            ApplyRotationToElements(figureRotation2Elements, transferX, transferY);

            MainContainer.Panel2.Refresh();
        }
        private void trackBarExtendable2_Scroll(object sender, EventArgs e)
        {
            TrackBar newScroll = (TrackBar)sender;

            float transferX, transferY;
            int currentScroll = scrollBar.GetCurrentScrollBar(newScroll.Name);

            (transferX, transferY) = GetScrollValues(newScroll, currentScroll, true);

            ApplyScalingToElements(figureExtendable2Elements, transferX, transferY);

            MainContainer.Panel2.Refresh();

        }
    }
}
