in_file = open('baby2008.txt', 'r')  
out_file = open('baby2008_out.txt', 'w')

print('The popular baby names starting with "b" are:')

num = 0; 
for line in in_file: 

    line = line.strip('\n')
    fields = line.split(' ')    
    
    rank, boyname, girlname = fields
    

    if (boyname.lower() < 'c') and (boyname.lower()) >= 'b':
     	print("%-10s %5s" % (boyname, rank))
		
    if (girlname.lower() < 'c') and (girlname.lower()) >= 'b':
	    print("%-10s %5s" % (girlname, rank))
		
    out_file.write("%s,%s\n" % (boyname, rank)) #print with aloghment 
    out_file.write("%s,%s\n" % (girlname, rank ))


in_file.close()
out_file.close()      


