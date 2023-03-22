using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_V2
{
    public partial class MainPage : Form
    {

        public void Custom()
        {
            SetControlCorners(ContainerTestCases, 25, 572, 582);
            SetControlCorners(textBoxLogs, 25, 506, 528);
            SetControlCorners(textBoxSummary, 25, 506, 528);
        }
        private void SetControlCorners(Control control, int cornerRadius, int width, int height)
        {
            GraphicsPath path = new GraphicsPath();
            int x = width - 2 * cornerRadius;
            int y = height - 2 * cornerRadius;
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(x, 0, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(x, y, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(0, y, cornerRadius, cornerRadius, 90, 90);
            control.Region = new Region(path);
            control.Padding = new Padding(cornerRadius, control.Padding.Top, cornerRadius, control.Padding.Bottom);
            control.Size = new Size(width, height);
        }
    }
}
