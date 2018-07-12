namespace ABallClassInWindowsForm
{
    public class Collider
    {
        public bool IsCollided(Pingpong ball, BlockPanel blockPanel)
        {
            return ball.VerticalCoordinate + ball.Height > blockPanel.VerticalCoordiante&&ball.HorizontalCoordinate+ball.Width/2>=blockPanel.HorizontalCoordinate&&ball.HorizontalCoordinate+ball.Width/2<=blockPanel.HorizontalCoordinate+blockPanel.Width;
        }
    }
}