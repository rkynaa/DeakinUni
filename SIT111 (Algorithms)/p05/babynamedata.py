in_file=open('baby2008.txt','r')
out_file=open('baby2008out.txt','w')
dict={}
for line in in_file:
    line = line.strip('\n')
    fields = line.split(' ')
    (rank, boyname, girlname) = fields

    # Add (name,rank) in dictionary 'dict'
    if boyname not in dict:
        dict[boyname] = rank
    if girlname not in dict:
        dict[girlname] = rank

# Print data sorted by name in alphabetical order
names = dict.keys()
sorted_names = sorted(names)
for name in sorted_names:
    rank = dict[name]
    out_file.write("%s,%s\n" %(name,rank))

in_file.close()
out_file.close()