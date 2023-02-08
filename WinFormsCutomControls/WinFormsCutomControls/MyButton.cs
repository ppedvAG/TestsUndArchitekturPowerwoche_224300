namespace WinFormsCutomControls
{
    public class MyButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(Brushes.Plum, pevent.ClipRectangle);
            pevent.Graphics.FillEllipse(Brushes.SteelBlue, pevent.ClipRectangle);
            

        }
    }

}
