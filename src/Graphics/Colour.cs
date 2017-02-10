using System;

public struct Colour {
    public static readonly Colour White = new Colour(5, 5, 5);
    public static readonly Colour Black = new Colour(0, 0, 0);

    public byte R { get; private set; }
    public byte G { get; private set; }
    public byte B { get; private set; }

    public Colour(byte r, byte g, byte b) {
        if (r > 5) throw new ArgumentOutOfRangeException("r", r, "0 <= r <= 5");
        if (g > 5) throw new ArgumentOutOfRangeException("g", g, "0 <= g <= 5");
        if (b > 5) throw new ArgumentOutOfRangeException("b", b, "0 <= b <= 5");

        this.R = r;
        this.G = g;
        this.B = b;
    }

    public byte ToAnsiColourCode() {
        return (byte)(16 + 36 * this.R + 6 * this.G + this.B);
    }

    public static bool operator ==(Colour c1, Colour c2) {
        return c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
    }

    public static bool operator !=(Colour c1, Colour c2) {
        return !(c1 == c2);
    }

    public override bool Equals(object o) {
        if (!(o is Colour)) return false;

        return this == (Colour)o;
    }

    public override int GetHashCode() {
        return (this.R << 8 + this.G) << 8 + this.B;
    }
}
