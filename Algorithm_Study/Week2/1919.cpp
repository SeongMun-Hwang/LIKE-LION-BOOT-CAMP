#include <iostream>
#include <vector>
#include <algorithm>
#include <cmath>

using namespace std;

int main() {
	string a, b;
	cin >> a >> b;
	vector<int> alphabet(26, 0);

	for (int i = 0; i < a.size(); i++) {
		alphabet[a[i] - 'a']++;
	}
	for (int i = 0; i < b.size(); i++) {
		alphabet[b[i] - 'a']--;
	}
	int sum = 0;
	for (int i = 0; i < alphabet.size(); i++) {
		sum += abs(alphabet[i]);

	}
	cout << sum;

	return 0;
}