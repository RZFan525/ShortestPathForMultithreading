clear
clc
num = 2000;
matrix = floor(unifrnd(5,1000,num,num));
map = ones(num*num-num,3);
k=1;
for i=1:num
    for j=1:num
        if i ~=j
            map(k,1) = i-1;
            map(k,2) = j-1;
            map(k,3) = matrix(i, j);
            k = k +1;
        end
    end
end