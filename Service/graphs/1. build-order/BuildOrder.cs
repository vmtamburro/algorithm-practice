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


    
    *********************Initial Implementation **********************

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



    Issues:

    1. Graph representation is a list of projects tha it depends on. Typically the reverse is done, so this makes checking dependencies more cumbersome.
    2. Efficiency of dependency checks. graph.Where(x => x.Value.Count() == 0 && !finalOrder.Contains(x.Key)) is called multiple times, and it performs a linear scan of the dictionary and the final order list each time. This can be inefficient for large input sizes.
    3. Maintaining final order: Using finalOrder.Contains(x.Key) inside the loop can lead to inefficient searches since Contains is O(n) for a list. Using a HashSet to track completed projects would be more efficient.
    4. The inner loop and the repeated filtering of projects can be optimized. Removing items from the list of dependencies is done in a nested loop, which can be optimized.
    */


    public List<char> BuildSolution(char[] arr, char[][] dependencies)
    {
        Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        Dictionary<char, int> inDegree = new Dictionary<char, int>();
        List<char> finalOrder = new List<char>();

        // Initialize graph and in-degree dictionary
        foreach (var project in arr)
        {
            graph[project] = new List<char>();
            inDegree[project] = 0;
        }

        // Build the graph and populate in-degree
        foreach (var dep in dependencies)
        {
            var parent = dep[0];
            var child = dep[1];
            graph[parent].Add(child);
            inDegree[child]++;
        }

        // Queue for projects with no dependencies
        Queue<char> toBuild = new Queue<char>();

        foreach (var project in inDegree.Where(p => p.Value == 0).Select(p => p.Key))
        {
            toBuild.Enqueue(project);
        }

        // Process the projects
        while (toBuild.Count > 0)
        {
            var proj = toBuild.Dequeue();
            finalOrder.Add(proj);

            foreach (var dependent in graph[proj])
            {
                inDegree[dependent]--;

                if (inDegree[dependent] == 0)
                {
                    toBuild.Enqueue(dependent);
                }
            }
        }

        // Check if all projects are in the build order
        if (finalOrder.Count != arr.Length)
        {
            throw new Exception("No valid build order exists.");
        }

        return finalOrder;
    }


    /* Improvements
        - Make key a project, and value the dependencies. Maintain an in-degree dictionary to count the number of dependencies the project has.
        - Use a queue to manage projects that can be built next (BFS). Avoids repeatedly filtering the list
        - Queue ensures we process each project once, adding dependents when their in-degree reaches zero (Topological Sorting)
    */




}