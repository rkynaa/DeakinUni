# import tne network x library using nx as short name
import networkx as nx

# import the graph plotting library using plt as short name
import matplotlib.pyplot as plt

# Graph initialization
G = nx.Graph()
G.addnodesfrom([1,2,3,4,5,6,7,8,9])
G.addedgesfrom([(1,2),(3,4),(2,5),(4,5),(6,7),(2,9),(5,7)])

nx.draw_random(G)

plt.axis('off')
plt.show()

# the nodes bigger (size = 400), colour the nodes blue, add labels by adding arguments to the method call draw random(...)
nx.draw_random(G, node_size =400, node_color ='b' , with_labels=True)

# To compute the degrees of each node in the graph,
D = nx.degree(G)
print(D)

# compute the average degree of a graph
def computeAvgDegree(Ds):
    sumDegrees = 0
    for node, degree in Ds : 
        sumDegrees += degree
    return sumDegrees/ len (Ds)
    
print ("Average degree : " + str(computeAvgDegree(D)))

# the Erdos-Renyi algorithm
# - generate graph
GER = nx.erdos_renyi_graph(60,0.15)

# - draw it using a random layout 
nx.draw_random(GER)

# - viualize and show it 
plt.axis ('off')
plt.show ()

# - the average degree of the Erdos-Renyi graph
# D is a structure (a list of pairs ) containing nodes 
# and their degrees returned by calling the degree function 
D = nx.degree(GER)

# convert elements from D into a dictionary with items of the form 
# ( nodeID : degree ) so that the built−in sorted function can be used 
D2 = {x : y for (x , y) in D} 

# sort the nodes according to their degrees , returning a list of nodeIDs 
SortedD2 = sorted(D2, key=D2.get, reverse=True)

# just print to check print ( SortedD2 )
# print the node ID and and the degree in sorted ( descending node degree order ) 
for nodeID in SortedD2 :
    print ("node: "+ str(nodeID)+", degree :"+ str(D2[nodeID]))

# GRAPH TRAVERSAL AND SEARCHING
# DFT (Depth-First Traversal) (Recursive)
def dft_recursive (graph, vertex, visits, item): 
    visits = visits + [vertex]

    # if we found the item in the graph 
    if (item == vertex): 
        return (visits, True)
    # else, keep searching 
    else : 
        answer = False 
        for neighbor in graph[vertex]: 
            if neighbor not in visits: 
                # The recursion happens here!
                (visits, answer) = dft_recursive(graph, neighbor, visits, item)
                # if answer is True, item found
                if (answer): 
                    break # we can break out of the for loop!
        return (visits, answer)

# BFT (Breadth-First Traversal) (Recursive)
def bft (graph, horizon, visits, item):
    # if there is no more nodes in the horizon 
    if horizon == [ ] : 
        return (visits, False)
    # if there are still nodes in the horizon
    # expand the horizon to get a new horizon
    else: 
        newhorizon = [ ] 
        for node in horizon : 
            if node not in visits: 
                visits = visits + [node] 
            newhorizon = newhorizon + graph[node]
        return bft(graph, newhorizon, visits, item)
