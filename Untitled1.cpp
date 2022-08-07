#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

using namespace std;

const long M = 20201234;

void nhapTamGiac(int &a, int &b, int &c) {
	cout << "Nhap 3 canh cua 1 tam giac: \n";
	cout << "\tNhap canh thu nhat: "; cin >> a;
	cout << "\tNhap canh thu hai : "; cin >> b;
	cout << "\tNhap canh thu ba  : "; cin >> c;
	
	while(!(a + b > c && a + c > b && c + b > a)) {
		cout << "Khong thoa man dieu kien! Moi nhap lai: \n";
		cout << "\tNhap canh thu nhat: "; cin >> a;
		cout << "\tNhap canh thu hai : "; cin >> b;
		cout << "\tNhap canh thu ba  : "; cin >> c;
	}
}

bool kiemTraCan(int a, int b, int c) {
	if(a == b || a == c || b == c) return true;
	else return false;
}

float tinh(int a, int b, int c) {
	float p = (float)(a + b + c) / 2;
	
	return sqrt(((p - a) * (p - b) * (p - c)) / p);
}

float F(int a, int b, int c, int k) {
	float r = tinh(a, b, c);
	float ans = 2022.0;
	
	for(int i = 1; i <= k; i++) {
		ans += 1 / r;
		r *= r;
	}
	
	return ans;
}

int main(){
	int a, b, c;
	nhapTamGiac(a, b, c);
	if(kiemTraCan(a, b, c)) cout << "Can\n";
	else cout << "Khong can\n";
	
	printf("Ban kinh duong tron noi tiep: %.3f\n", tinh(a, b, c));
	
	int k = M % 5 + 5;
	printf("F(%d, %d, %d, %d) = %.3f\n", a, b, c, k, F(a, b, c, k));
    return 0;
}

