using System.Collections.Generic;

namespace Wem.Yaml {

  /**
   * Deserialized representation of an agenda.
   */
  public class DeserializedAgenda {
    public string Id {get; set;}
    public List<DeserializedActivity> Activities {get; set;}

    /**
     * DeserializedAgenda constructor.
     */
    public DeserializedAgenda() {
      this.Activities = new List<DeserializedActivity> ();
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      string activities = "";
      for (int i = 0; i < Activities.Count; i++) {
        activities += Activities[i];

        if (i < Activities.Count - 1) {
          activities += "\t";
        }
      }

      return Id + ":\n\t" + activities;
    }
  }

  /**
   * Deserialized representation of an activity.
   */
  public class DeserializedActivity {
    public string Name {get; set;}
    public string Id {get; set;}
    public bool IsRoot {get; set;}
    public string Class {get; set;}
    public List<string> Adjacents {get; set;}

    /**
     * Activity constructor.
     */
    public DeserializedActivity() {
      this.IsRoot = false;
      Adjacents = new List<string> ();
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      string format = "{0}:\n" +
        "\t\tid: {1}\n" +
        "\t\tis_root: {2}\n" +
        "\t\tclass: {3}\n" +
        "\t\tadjacents: {4}\n";

      string adjacents = "";
      for (int i = 0; i < Adjacents.Count; i++) {
        adjacents += Adjacents[i];

        if (i < Adjacents.Count - 1) {
          adjacents += ", ";
        }
      }

      return string.Format(format, Name, Id, IsRoot, Class, adjacents);
    }
  }
}
