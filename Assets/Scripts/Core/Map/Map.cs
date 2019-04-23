using System.Collections.Generic;
using Wem.Container;
using Wem.Generic;

namespace Wem.Map {

  public class Map : IMap {

    /**
     * {@inheritdoc}
     */
    public string Id {get; set;}

    /**
     * {@inheritdoc}
     */
    public List<Area> Areas {get; set;}

    public static Map create(IContainer container) {
      return new Map();
    }

    /**
     * Area constructor.
     */
    public Map() {
      this.Areas = new List<Area> ();
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      string areas = "";
      foreach (Area area in Areas) {
        areas += area + "\n";
      }

      return string.Format("{0}:\n{1}", this.Id, areas);
    }

  }

}
