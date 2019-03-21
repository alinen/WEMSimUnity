
namespace Wem.Activity {

  public class EdgeConfig {
    double probability;

    public ActivityInterface Adjacent;

    public EdgeConfig(ActivityInterface node, double probability) {
      this.Adjacent = node;
      this.probability = probability;
    }

  }

}
