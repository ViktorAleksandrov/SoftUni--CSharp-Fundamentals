namespace P06.TrafficLights
{
    public class TrafficLight
    {
        private LightColor lightColor;

        public TrafficLight(LightColor color)
        {
            this.lightColor = color;
        }

        public void ChangeColor()
        {
            this.lightColor++;

            if ((int)this.lightColor > 2)
            {
                this.lightColor = 0;
            }
        }

        public override string ToString()
        {
            return $"{this.lightColor}";
        }
    }
}
