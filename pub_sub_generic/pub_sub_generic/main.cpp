#include "pub_sub.h"
using namespace pub_sub;

class AEventArgs: public EventArgs
{
private:
	string s_;
public:
	explicit AEventArgs(const string& s) : s_(s) {}
	const string& data() const { return s_; }
};

class BEventArgs: public EventArgs
{
private:
	string s_;
public:
	explicit BEventArgs(const string& s) : s_(s) {}
	const string& data() const { return s_; }
};

class CSubscriber: public Subscriber
{
public:
	explicit CSubscriber(const string& name) : Subscriber(name) {}
	template <typename T>
	void OnEventReceived(void* pSender, const EventArgs& args) 
	{
		const T* const s = dynamic_cast<const T* const>(&args);
		if (s == nullptr)
			return;
		if (pSender == nullptr)
			return;
		Publisher* p = static_cast<Publisher*>(pSender);
		cout<<"unexpected message received by " << name_ <<endl;
	}
	template <>
	void OnEventReceived<AEventArgs>(void* pSender, const EventArgs& args) 
	{
		const AEventArgs* const s = dynamic_cast<const AEventArgs* const>(&args);
		if (s == nullptr)
			return;
		if (pSender == nullptr)
			return;
		Publisher* p = static_cast<Publisher*>(pSender);
		cout<<"A events received by " << name_ <<":"<<s->data()<<endl;
	}
	template <>
	void OnEventReceived<BEventArgs>(void* pSender, const EventArgs& args) 
	{
		const BEventArgs* const s = dynamic_cast<const BEventArgs* const>(&args);
		if (s == nullptr)
			return;
		if (pSender == nullptr)
			return;
		Publisher* p = static_cast<Publisher*>(pSender);
		cout<<"B events received by " << name_ <<":"<<s->data()<<endl;
	}
};


int main() {
	Publisher p("publisher");
	CSubscriber s1("Csubscriber1");
	CSubscriber s2("Csubscriber2");
	long token11 = Subscribe<AEventArgs, CSubscriber>(p, s1);
	long token12 = Subscribe<BEventArgs, CSubscriber>(p, s1);
	long token21 = Subscribe<AEventArgs, CSubscriber>(p, s2);
	p.Publish<AEventArgs>("233");
	p.Publish<BEventArgs>("SB");
	Unsubscribe(p, token11);
	p.Publish<AEventArgs>("666");
	p.Publish<BEventArgs>("666");

	system("pause");
	return 0;
}