#include<iostream>
#include <deque>
#include<algorithm>
#include<cmath>
#include<climits>
using namespace std;

int main() {
	ios_base::sync_with_stdio(false);
	cin.tie(NULL);

	int n;
	cin >> n;
	deque<int> q;

	for (int i = n; n > 0; n--) {
		q.push_front(n);
		for (int j = 0; j < n; j++) {
			q.push_front(q.back());
			q.pop_back();
		}
	}
	for (int i = 0; i < q.size(); i++) {
		cout << q[i] << " ";
	}
}