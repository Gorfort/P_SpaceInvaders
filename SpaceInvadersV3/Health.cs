namespace SpaceInvadersV3
{
    public class Health
    {
        private int health;

        public Health(int initialHealth)
        {
            health = initialHealth;
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        public void DecreaseHealth()
        {
            health--;
        }

        public void IncreaseHealth()
        {
            health++;
        }
    }
}
