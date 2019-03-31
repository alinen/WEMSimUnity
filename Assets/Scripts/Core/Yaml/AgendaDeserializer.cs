using System;
using System.Collections.Generic;
using System.IO;
using Wem.Container;

namespace Wem.Yaml {

  public class AgendaDeserializer : Deserializer {

    public static AgendaDeserializer create(IContainer container) {
      return new AgendaDeserializer();
    }

    /**
     * Deserializes a list of YAML files.
     *
     * @param List<string> files
     *   The files to deserialize.
     */
    public List<DeserializedAgenda> Deserialize(List<string> files = null) {

      List<DeserializedAgenda> agendas = new List<DeserializedAgenda> ();

      foreach(string path in files) {
        agendas.Add(this.deserializeFile(path));
      }

      return agendas;
    }

    /**
     * Deserializes a YAML file.
     *
     * @param string path
     *   The path to the file.
     */
    private DeserializedAgenda deserializeFile(string path) {
      DeserializedAgenda agenda = new DeserializedAgenda();

      var file = new StreamReader(path);

      var input = deserializer.Deserialize<dynamic>(file);

      foreach(var agendaNode in input) {
        agenda.Name = agendaNode.Key;

        var activities = agendaNode.Value;

        foreach(var activity in activities) {
          agenda.Activities.Add(this.deserializeActivity(activity));
        }
      }

      return agenda;
    }

    /**
     * Deserializes an activity node.
     *
     * @param KeyValuePair<object, object> activity_node
     *   The activity node with the configuration values.
     */
    private DeserializedActivity deserializeActivity(KeyValuePair<object, object> activity_node) {
      DeserializedActivity activity = new DeserializedActivity();

      activity.Name = activity_node.Key.ToString();

      Dictionary<object, object> settings = (Dictionary<object, object>) activity_node.Value;
      activity.Id = settings["id"].ToString();
      activity.Class = settings["class"].ToString();

      // Checks if activity is root.
      object is_root;
      if (settings.TryGetValue("is_root", out is_root)) {
        activity.IsRoot = Boolean.Parse(is_root.ToString());
      }

      // Gets adjacent nodes.
      List<object> adjacents = (List<object>) settings["adjacents"];
      foreach(var adj in adjacents) {
        activity.Adjacents.Add(adj.ToString());
      }

      return activity;
    }

  }

}
