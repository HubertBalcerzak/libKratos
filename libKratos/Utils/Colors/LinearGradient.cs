namespace LibKratos.Utils.Colors {
    public class LinearGradient: IGradient {
        private float _maxValue;

        public LinearGradient(float maxValue) {
            _maxValue = maxValue;
        }

        public (float, float, float) GetColor(float value) {
            float region = value / _maxValue;

            float red;
            if (region > 0.75) red = 1;
            else if (region > 0.5) red = (region - 0.5f) * 4;
            else red = 0;

            float green;
            if (region > 0.75) green = (1 - region) * 4;
            else if (region > 0.25) green = 1;
            else green = region * 4;

            float blue;
            if (region > 0.5) blue = 0;
            else if (region > 0.25) blue = (1 - region - 0.5f) * 4f;
            else blue = 1;

            return (red, green, blue);
        }
    }
}