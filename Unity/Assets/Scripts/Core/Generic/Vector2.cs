using System;

namespace Wem.Generic {

  /**
   * A 2D vector where to draw an area.
   */
  public class Vector2 {
    public int X {get; set;}
    public int Y {get; set;}

    /**
     * Vector2 constructor.
     */
    public Vector2(string coord) {
      // A string coordinates comes as a X,Y (e.g.: -50,0).
      string[] coords = coord.Split(',');

      this.X = Int32.Parse(coords[0]);
      this.Y = Int32.Parse(coords[1]);
    }

    public override string ToString() {
      return string.Format("({0}, {1})", this.X, this.Y);
    }

  }

}
