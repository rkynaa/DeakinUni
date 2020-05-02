import sys
def extract_name(filename):
    """
    Given a file name for babyxxxx.txt, returns a list of
    name-rank strings in alphabetical order. e.g.
    ['Aaliyah,91', 'Aaron,57', 'Abagail,895',...]
    """
    in_file=open(filename,'r')
    dict={}

    for line in in_file:
        line = line.strip('\n')
        fields = line.split(' ')
        (rank, boyname, girlname)=fields

        # Add (name,rank) in dictionary 'dict'
        if boyname not in dict:
            dict[boyname] = rank
        if girlname not in dict:
            dict[girlname] = rank

    names = dict.keys()
    sorted_names = sorted(names)

    names_to_return=[]
    for name in sorted_names:
        rank = dict[name]
        names_to_return.append(name + ',' + rank)

    in_file.close()
    return names_to_return

args = sys.argv[1:]
if not args:
    print('usage: file[file...]')
    sys.exit(1)

for filename in args:
    nameranks=extract_name(filename)
    out_file = open(filename+'.summary','w')
    for namerank in nameranks:
        out_file.write(namerank+'\n')
    out_file.close()