using System.Collections.Generic;
using Wem.Container;
using Wem.Generic;

namespace Wem.Map {

  public class Map : IMap {

    /**
     * {@inheritoc}
     */
    public Dictionary<string, Area> Areas {get; protected set;}

    /**
     * {@inheritdoc}
     */
    public string Id {get; set;}

    public static Map create(IContainer container) {
      return new Map();
    }

    public Map() {
      this.Areas = new Dictionary<string, Area> ();
    }

    public void AddArea(string id, Area area) {
      this.Areas.Add(id, area);
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      string areas = "";
      foreach (KeyValuePair<string, Area> area in this.Areas) {
        areas += area.Value + "\n";
      }

      return string.Format("{0}:\n{1}", this.Id, areas);
    }

  }

}
