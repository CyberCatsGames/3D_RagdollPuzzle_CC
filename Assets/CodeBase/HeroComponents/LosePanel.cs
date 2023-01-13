namespace CodeBase.HeroComponents
{
    public class LosePanel : Window
    {
        public static LosePanel Instance { get; private set; }

        private void Start()
        {
            Instance = this;
            gameObject.SetActive(false);
        }
    }
}