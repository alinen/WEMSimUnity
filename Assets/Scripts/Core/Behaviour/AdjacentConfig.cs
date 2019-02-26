
namespace Wem.Behaviour {

  public class AdjacentConfig {
    double probability;

    public WemBehaviourInterface Adjacent;

    public AdjacentConfig(WemBehaviourInterface node, double probability) {
      this.Adjacent = node;
      this.probability = probability;
    }

  }

}
