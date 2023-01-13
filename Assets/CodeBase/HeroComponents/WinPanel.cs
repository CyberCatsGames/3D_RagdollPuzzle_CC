namespace CodeBase.HeroComponents
{
    public class WinPanel : Window
    {
        public static WinPanel Instance { get; private set; }

        private void Start()
        {
            Instance = this;
            gameObject.SetActive(false);
        }
    }
}