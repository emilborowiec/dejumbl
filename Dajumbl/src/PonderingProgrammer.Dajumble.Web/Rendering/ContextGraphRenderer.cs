using System.Collections.Generic;
using PonderingProgrammer.Dajumble.Web.Model;
using QuikGraph;
using QuikGraph.Graphviz;

namespace PonderingProgrammer.Dajumble.Web.Rendering
{
    public static class ContextGraphRenderer
    {
        public static string ToGraphviz(this Context context)
        {
            var edges = new List<TaggedEdge<ContentItem, RelationType>>();
            
            foreach (var item in context.Items)
            {
                foreach (var relation in item.OutgoingRelations)
                {
                    var edge = new TaggedEdge<ContentItem, RelationType>(item, relation.Target, relation.RelationType);
                    edges.Add(edge);
                }
            }

            var graph = edges.ToAdjacencyGraph<ContentItem, TaggedEdge<ContentItem, RelationType>>();

            return graph.ToGraphviz().Replace(System.Environment.NewLine, "");
        }
    }
}