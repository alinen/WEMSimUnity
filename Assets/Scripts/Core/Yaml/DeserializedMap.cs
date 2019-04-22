using System;
using System.Collections.Generic;
using Wem.Generic;

namespace Wem.Yaml {

  /**
   * Deserialized representation of a map.
   */
  public class DeserializedMap {
    public string Id {get; set;}
    public List<DeserializedArea> Areas {get; set;}

    /**
     * DeserializedMap constructor.
     */
    public DeserializedMap() {
      this.Areas = new List<DeserializedArea> ();
    }

    public override string ToString() {
      string areas = "";
      foreach (DeserializedArea area in Areas) {
        areas += area + "\n";
      }

      return string.Format("{0}:\n{1}", this.Id, areas);
    }
  }

  /**
   * Deserialized representation of an area.
   */
  public class DeserializedArea {
    public string Id;
    public List<Vector2> Coordinates = new List<Vector2> ();
    public List<ActivityRef> Activities = new List<ActivityRef> ();
    public Link Link;

    public override string ToString() {
      string format = "\t{0}\n" +
        "\t\tcoordinates: {1}\n" +
        "\t\tactivities:\n {2}" +
        "\t\tlink: {3}";

      string activities = "";
      foreach (ActivityRef activity in this.Activities) {
        activities = "\t\t\t" + activity + "\n";
      }

      string coordinates = "";
      for (int i = 0; i < this.Coordinates.Count; i++) {
        if (i != 0) {
          coordinates += ", ";
        }

        coordinates += this.Coordinates[i];
      }

      return string.Format(format, this.Id, coordinates, activities, this.Link);
    }
  }

  /**
   * Activity reference.
   */
  public class ActivityRef {
    public string Agenda {get; set;}
    public string Activity {get; set;}

    public ActivityRef(string activity) {
      string[] parts = activity.Split(new[] { "::" }, StringSplitOptions.None);

      this.Agenda = parts[0];
      this.Activity = parts[1];
    }

    public override string ToString() {
      return this.Agenda + "::" + this.Activity;
    }
  }

  /**
   * Deserialized representation of a link.
   */
  public class Link {
    public string Area = null;
    public string Agenda = null;
    public string Activity = null;

    /**
     * Link constructor.
     */
    public Link(string link) {
      if (link == null) return;

      // A link comes as area|agenda::activity
      // (e.g. pickup1.area|example.agenda::pickup.activity)
      string[] parts = link.Split('|');

      if (parts.Length < 0) return;

      this.Area = parts[0];

      string[] act_tokens = parts[1].Split(new[] { "::" }, StringSplitOptions.None);
      this.Agenda = act_tokens[0];
      this.Activity = act_tokens[1];
    }

    public override string ToString() {
      if(this.Area == null || this.Agenda == null || this.Activity == null) {
        return "none";
      }

      return this.Area + "|" + this.Agenda + "::" + this.Activity;
    }
  }

}
