using System.Collections.Generic;
using Wem.Generic;

namespace Wem.Map {

  public interface IMap {

    /**
     * The ID of the map.
     */
    string Id {get; set;}

    /**
     * The areas of the map.
     */
    Dictionary<string, Area> Areas {get;}

    void AddArea(string id, Area area);

  }

}
