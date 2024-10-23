#include<iostream>
#include <vector>
#include<algorithm>
#include<stack>
using namespace std;

int count1 = 1;
int count2 = 0;

int fib(int n) {
	if (n == 1 || n == 2) return 1;
	else {
		count1++;
		return fib(n - 1) + fib(n - 2);
	}
}

int fibonacci(int n) {
	int* f = new int[n] {0};
	f[0] = 1;
	f[1] = 1;
	for (int i = 2; i < n; i++) {
		count2++;
		f[i] = f[i - 1] + f[i - 2];
	}
	return f[n - 1];
}

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);
	int n;
	cin >> n;

	fib(n);
	fibonacci(n);

	cout << count1 << "\n" << count2;
}