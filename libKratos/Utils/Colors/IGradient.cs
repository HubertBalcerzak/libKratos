namespace LibKratos.Utils.Colors {
    public interface IGradient {
        (float, float, float) GetColor(float value);
    }
}