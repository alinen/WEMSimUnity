using System;
using System.Collections.Generic;
using System.IO;
using Wem.Agenda;
using Wem.Container;
using Wem.Generic;

namespace Wem.Yaml {

  public class MapDeserializer : Deserializer {

    public static MapDeserializer create(IContainer container) {
      return new MapDeserializer();
    }

    /**
     * Deserializes a YAML file for a map.
     *
     * @param string path
     *   The path to the file to deserialize.
     */
    public DeserializedMap Deserialize(string path) {
      DeserializedMap map = new DeserializedMap();

      var file = new StreamReader(path);

      var input = deserializer.Deserialize<dynamic>(file);

      foreach(var map_node in input) {
        map.Id = map_node.Key;

        var areas = map_node.Value;

        // Deserializes the areas.
        foreach(var area in areas) {
          map.Areas.Add(this.deserializeArea(area));
        }
      }

      return map;
    }

    /**
     * Deserializes an area node.
     *
     * @param KeyValuePair<object, object> area_node
     *   The area node with the configuration values.
     */
    private DeserializedArea deserializeArea(KeyValuePair<object, object> area_node) {
      DeserializedArea deserialized_area = new DeserializedArea();

      deserialized_area.Id = area_node.Key.ToString();

      Dictionary<object, object> settings = (Dictionary<object, object>) area_node.Value;

      // Gets the coordinates of the area.
      List<Vector2> coordinates = deserializeCoordinates((List<object>)settings["coordinates"]);
      foreach (Vector2 coordinate in coordinates) {
        deserialized_area.Coordinates.Add(coordinate);
      }

      // Gets the activities that are allowed in the area.
      List<ActivityRef> activities = deserializeActivities((List<object>)settings["activities"]);
      foreach (ActivityRef activity in activities) {
        deserialized_area.Activities.Add(activity);
      }

      // Gets the link (the previous area) if available.
      object link;
      if (!settings.TryGetValue("link", out link)) {
        link = null;
      }
      deserialized_area.Link = new Link((string) link);

      return deserialized_area;
    }

    /**
     * Deserializes the coordinates of an area.
     *
     * @param List<object> coordinates
     *   The string list with coordinates.
     *
     * @return List<Vector2>
     *   The deserialized list of coordinate vectors.
     */
    private List<Vector2> deserializeCoordinates(List<object> coordinates) {

      List<Vector2> vectors = new List<Vector2> ();

      foreach(string coordinate in coordinates) {
        Vector2 coord = new Vector2(coordinate);

        vectors.Add(coord);
      }

      return vectors;
    }

    /**
     * Deserializes the activities allowed in an area.
     *
     * @param List<object> activities
     *   The string list of activities.
     *
     * @return List<ActivityRef>
     *   The deserialized list of activities.
     */
    private List<ActivityRef> deserializeActivities(List<object> activities) {
      List<ActivityRef> activity_refs = new List<ActivityRef> ();

      foreach(string activity in activities) {
        ActivityRef activity_ref = new ActivityRef(activity);

        activity_refs.Add(activity_ref);
      }

      return activity_refs;
    }

  }

}
