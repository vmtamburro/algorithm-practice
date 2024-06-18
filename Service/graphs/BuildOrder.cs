public class BuildOrder
{
    /* 
        You are given a list of projects, and a list of dependencies (which is a list of pairs of projects, where the second project is dependent on the first project)
        All of a project's dependencies must be built before the project is. Find a build order that will allow the projects to be built.
        If there is no valid build order return an error.


        example input:
            projects: a, b, c, d, e, f
            dependencies: (a, d), (f, b), (b, d), (f, a), (d, c)

        This is probably going to be some sort of a graph. 

        - First build the projects that have dependencies, are not dependent. 
        - Second, find the things that were dependent on our currently built nodes. Remove dependencies from previous nodes.
        - Repeat.
        - If things are remaining and they still have dependencies, there's no way to build the project, throw an error


    */


    public List<char> BuildSolution(char[] arr, char[][] dependencies)
    {
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        List<char> finalOrder = new List<char>();


        // Generate Graph
        for (var i = 0; i < arr.Length; i++)
        {
            graph[arr[i]] = new List<char>();
        }

        // Add a reference to each project's parent
        foreach (var dep in dependencies)
        {
            var parent = dep[0];
            var child = dep[1];
            graph[child].Add(parent);
        }

        var toBuild = graph.Where(x => x.Value.Count() == 0 && !finalOrder.Contains(x.Key)).Select(y => y.Key).ToList(); // first get the projects that are not dependent on anything
        while (toBuild.Count > 0)
        {
            var nextToBuild = new List<char>();
            foreach (var proj in toBuild)
            {
                // get dependents of these projects
                var dependents = graph.Where(x => x.Value.Contains(proj));

                // remove the parents from their parents value
                foreach (var dep in dependents)
                {
                    graph[dep.Key].Remove(proj);
                }

                // add to final order
                finalOrder.Add(proj);

            }
            toBuild = graph.Where(x => x.Value.Count() == 0 && !finalOrder.Contains(x.Key)).Select(y => y.Key).ToList(); // get the next projects that are not dependent on anything
        }

        // Check if all projects are in the build order
        if (finalOrder.Count != arr.Length)
        {
            throw new Exception("No valid build order exists.");
        }


        return finalOrder;



    }



}