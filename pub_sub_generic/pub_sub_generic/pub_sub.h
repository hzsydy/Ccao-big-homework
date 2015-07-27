#pragma once
#ifndef __PUB_SUB_H
#define __PUB_SUB_H


#include "define.h"
#include <functional>
#include <string>
#include <map>
#include <algorithm>
#include <iostream>

using std::string;
using std::function;
using std::map;
using std::pair;
using namespace std::placeholders;
using std::cout;
using std::endl;

namespace pub_sub
{
	/*EventArgs 
	字面意思。酷爱来继承我吖
	*/
	class EventArgs 
	{
	public:
		virtual ~EventArgs() {}
	};

	class StringEventArgs : public EventArgs 
	{
	private:
		string payload_;
	public:
		explicit StringEventArgs(const string& payload) : payload_(payload) {}
		const string& Payload() const { return payload_; }
	};


	class Event 
	{
	private:
		template <typename T>
		class Callback 
		{
		private:
			void* pSender_;
			const EventArgs& args_;

		public:
			Callback(void* pSender, const EventArgs& args) : pSender_(pSender), args_(args) {}
			void operator()(pair<long, function<void(void*, const EventArgs&)>> p) const 
			{
				p.second(pSender_, args_);
			}
		};
		map<long, function<void(void*, const EventArgs&)>> callbacks_;
		long token_;

	public:
		explicit Event():token_(0){}
		template <typename T>
		void call(void* pSender, const EventArgs& args) const 
		{
			for_each(callbacks_.begin(), callbacks_.end(), Callback<T>(pSender, args));
		}
		long Subscribe(function<void(void*, const EventArgs&)> f) 
		{
			token_++;
			callbacks_.insert(make_pair(token_, f));
			return token_;
		}
		void Unsubscribe(long token) 
		{
			callbacks_.erase(token);
		}
	};

	/*Publisher
	重载Publish来获得效果
	*/
	class Publisher 
	{
	protected:
		Event event_;
		string name_;

	public:
		explicit Publisher(const string& name) : name_(name) {}
		const string& Name() const { return name_; }
		template <typename T>
		void Publish(const string& message) 
		{
			event_.call<T>(this, T(message));
		}
		long Register(function<void(void*, const EventArgs&)> f) 
		{
			return event_.Subscribe(f);
		}
		void Unregister(long token) {
			event_.Unsubscribe(token);
		}
	};

	/*Subscriber 
	重载OnEventReceived来获得效果
	*/
	class Subscriber 
	{
	protected:
		string name_;
	public:
		explicit Subscriber(const string& name) : name_(name) {}
		template <typename T>
		void OnEventReceived(void* pSender, const EventArgs& args) 
		{
			const T* const s = dynamic_cast<const T* const>(&args);
			if (s == nullptr)
				return;
			if (pSender == nullptr)
				return;
			Publisher* p = static_cast<Publisher*>(pSender);
			cout<<"unexpected message received: " << name_ <<endl;
		}
	};


	template <typename T, typename sub>
	long Subscribe(Publisher& publisher, sub& subscriber) 
	{
		return publisher.Register(bind(&sub::OnEventReceived<T>, &subscriber, _1, _2));
	}

	void Unsubscribe(Publisher& publisher, long token) 
	{
		publisher.Unregister(token);
	}

	class Subscription 
	{
	private:
		Publisher& publisher_;
		long token_;

	public:
		Subscription(Publisher& publisher, long token) : publisher_(publisher), token_(token) {}
		~Subscription() 
		{
			publisher_.Unregister(token_);
		}
	};
}//namespace pub_sub


#endif