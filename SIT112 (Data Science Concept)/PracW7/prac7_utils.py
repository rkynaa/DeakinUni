# S. Shelyag 30/04/2020
# This is a very unpleasant implementation of K-means algorithm.
# The original version (which I have inherited with SIT112 unit) was
# incorrect and produced a number of warnings.
# This version is still methodologically incorrect in initialisation
# of cluster centroids for the given data.
# I tried my best to fix it, but I think the main purpose of this program
# should be to demonstrate how _NOT_ to write programs in general,
# and in particular in python.
# This is a perfect example of careless coding, where a number of 
# syntactically nearly incorrect and obscure shortcuts are taken. 
# Note that these shortcuts are currently being cut out of python 
# standard for good.
#
# For a better demonstration of K-means algorithm use the 'other' 
# python program provided with the lecture.
#
# If there will be next year and I am still to teach SIT112 next year,
# I will remove this program completely.


import numpy as np
import matplotlib.pyplot as plt

def plot_kmeans_interactive(min_clusters=1, max_clusters=6):
    from ipywidgets import interact
    from sklearn.metrics.pairwise import euclidean_distances
    from sklearn.datasets import make_blobs


    X, y = make_blobs(n_samples=300, centers=4,
                      random_state=0, cluster_std=0.60)

    def _kmeans_step(frame=0, n_clusters=4):
        rng = np.random.RandomState(4)
        labels = np.zeros(X.shape[0])
        centers = rng.randn(n_clusters, 2)

        nsteps = frame // 3

        for i in range(nsteps + 1):
            old_centers = centers
            if i < nsteps or frame % 3 > 0:
                dist = euclidean_distances(X, centers)
                labels = dist.argmin(1)

            if i < nsteps or frame % 3 > 1:
                tmp = []
                for j in range(n_clusters):
                    index = [labels == j]
                    if (np.sum(index) >0):
                        tmp.append(X[tuple(index)].mean(0))
                    else:
                        tmp.append([np.nan,np.nan])
                centers = np.array([tmp])[0]
                nans = np.isnan(centers)
                centers[nans] = old_centers[nans]


        # plot the data and cluster centers
        plt.scatter(X[:, 0], X[:, 1], c=labels, s=50, cmap='rainbow',
                    vmin=0, vmax=n_clusters - 1);
        plt.scatter(old_centers[:, 0], old_centers[:, 1], marker='o',
                    c=np.arange(n_clusters),
                    s=200, cmap='rainbow')
        plt.scatter(old_centers[:, 0], old_centers[:, 1], marker='o',
                    c='black', s=50)

        # plot new centers if third frame
        if frame % 3 == 2:
            for i in range(n_clusters):
                plt.annotate('', centers[i], old_centers[i], 
                             arrowprops=dict(arrowstyle='->', linewidth=1))
            plt.scatter(centers[:, 0], centers[:, 1], marker='o',
                        c=np.arange(n_clusters),
                        s=200, cmap='rainbow')
            plt.scatter(centers[:, 0], centers[:, 1], marker='o',
                        c='black', s=50)

        plt.xlim(-4, 4)
        plt.ylim(-2, 10)

        if frame % 3 == 1:
            plt.text(3.8, 9.5, "1. Reassign points to nearest centroid",
                     ha='right', va='top', size=14)
        elif frame % 3 == 2:
            plt.text(3.8, 9.5, "2. Update centroids to cluster means",
                     ha='right', va='top', size=14)

    
    return interact(_kmeans_step, frame=np.arange(50),
                    n_clusters=np.arange(min_clusters, max_clusters))
