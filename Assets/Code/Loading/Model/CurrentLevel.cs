namespace Code.Loading.Model
{
    public class CurrentLevel
    {
        public int CurentLevel => _curentLevel;
        private int _curentLevel;

        public CurrentLevel()
        {
            _curentLevel = 0;
        }

        public void ChangeLevel()
        {
            _curentLevel++;
        }
    }
}