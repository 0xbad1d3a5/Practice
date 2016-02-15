# Enter your code here. Read input from STDIN. Print output to STDOUT

import sys

count = None
triangles = []

for line in sys.stdin:
    line = line.strip()
    if not count:
        count = int(line)
    else:
        triangles.append([int(x) for x in line.split(' ')])
        
for t in triangles:
    
    if t[0] == t[1] and t[1] == t[2]:
        print "Equilateral"
    else:
        if t[0] in [t[1], t[2]] or t[1] in [t[0], t[2]] or t[2] in [t[0], t[1]]:
            print "Isosceles"
        else:
            print "None of these"
