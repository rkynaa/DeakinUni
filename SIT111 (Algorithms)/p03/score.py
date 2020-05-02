# 1st student
name1 = raw_input('Enter 1st student name: ')
score1 = raw_input('Enter 1st student score: ')

# 2nd student
name2 = raw_input('Enter 2nd student name: ')
score2 = raw_input('Enter 2nd student score: ')

# 3rd student
name3 = raw_input('Enter 3rd student name: ')
score3 = raw_input('Enter 3rd student name: ')

print('|---------------------|')
print('| %10s | %6s |' %('Name', 'Score'))
print('|---------------------|')
print('| %10s | %6s |' %(name1, score1))
print('| %10s | %6s |' %(name2, score2))
print('| %10s | %6s |' %(name3, score3))
print('|---------------------|')

# Calculating average
sum = int(score1) + int(score2) + int(score3)
average = float(sum)/3
print('The student score average is: %.1f' %(average))
