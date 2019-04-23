using System.Collections.Generic;
using Wem.Generic;

namespace Wem.Map {

  public interface IMap {

    /**
     * The ID of the map.
     */
    string Id {get; set;}

    /**
     * The areas in the map.
     */
    List<Area> Areas {get; set;}

  }

}
