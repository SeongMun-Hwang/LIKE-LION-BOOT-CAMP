#include<iostream>
#include <vector>
#include<algorithm>
#include<cmath>
#include<climits>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	int n;
	cin >> n;
	vector<long long> v(n);
	for (int i = 0; i < n; i++) {
		cin >> v[i];
	}
	sort(v.begin(), v.end());

	long long closest_sum = LLONG_MAX;
	long long a = 0, b = 0, c = 0;

	for (int i = 0; i < n - 2; i++) {
		int left = i + 1;
		int right = n - 1;

		while (left < right) {
			long long sum = v[i] + v[left] + v[right];
			if (abs(sum) < abs(closest_sum)) {
				closest_sum = sum;
				a = v[i];
				b = v[left];
				c = v[right];
			}
			if (sum < 0) {
				left++;
			}
			else {
				right--;
			}
		}
	}
	cout << a << " " << b << " " << c;
}