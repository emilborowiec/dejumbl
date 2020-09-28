using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using PonderingProgrammer.Dajumble.Web.Model;

namespace PonderingProgrammer.Dajumble.Web.Rendering
{
    public static class ContextGraphRenderer
    {
        public static string ToGraphviz(this Context context)
        {
            var graph = new DotGraph(isDirected: true);

            foreach (var item in context.Items)
            {
                graph.Nodes.Add(item.Id, attrs =>
                {
                    attrs.Label = item.Label;
                    attrs.Style = DotStyles.Filled;
                    attrs.FillColor = Color.Blue;
                });
            }
            
            foreach (var item in context.Items)
            {
                foreach (var relation in item.OutgoingRelations)
                {
                    graph.Edges.Add(item.Id, relation.Target.Id, edge =>
                    {
                        edge.Attributes.Label = relation.RelationType.ToString();
                        edge.Attributes.Color = Color.Red;
                    });
                }
            }

            return graph.Build().Replace(System.Environment.NewLine, "");
        }
    }
}