#include<iostream>
#include<stack>
#include<vector>
using namespace std;

long long fibonacci(int n) {
	std::vector<long long> dp(n + 1, 1);

	for (int i = 2; i <= n; i++) {
		dp[i] = (dp[i - 1] + dp[i - 2]) % 10007;
	}
	return dp[n];
}

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	int n;
	cin >> n;
	cout << fibonacci(n) << "\n";
}