using System.Collections.Generic;
using Wem.Generic;
using Wem.Yaml;

namespace Wem.Map {

  public class Area {

    /**
     * Reference to the representing deserialized area.
     */
    protected DeserializedArea deserializedArea;

    public string Id {get; protected set;}
    public List<Vector2> Coordinates {get; protected set;}
    public List<ActivityRef> Activities {get; protected set;}
    public Link Link{get; protected set;}


    public Area(DeserializedArea deserialized_area) {
      this.deserializedArea = deserialized_area;

      /**
       * The fields of this class are references to the fields of the given
       * deserialized map.
       */
      this.Id = this.deserializedArea.Id;
      this.Coordinates = this.deserializedArea.Coordinates;
      this.Activities = this.deserializedArea.Activities;
      this.Link = this.deserializedArea.Link;
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      return this.deserializedArea.ToString();
    }

  }

}
