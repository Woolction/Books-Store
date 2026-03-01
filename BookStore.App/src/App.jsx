import React from "react";
import { motion } from "framer-motion";
import { BookOpen, Search, Menu } from "lucide-react";

export default function BookPlatform() {
  const books = [
    { id: 1, title: "Atomic Habits", author: "James Clear" },
    { id: 2, title: "Deep Work", author: "Cal Newport" },
    { id: 3, title: "Clean Code", author: "Robert C. Martin" },
    { id: 4, title: "The Psychology of Money", author: "Morgan Housel" },
  ];

  return (
    <div className="min-h-screen bg-black text-white font-sans">
      <header className="flex items-center justify-between px-6 py-4 border-b border-neutral-800">
        <div className="flex items-center gap-2 text-xl font-semibold tracking-wide">
          <BookOpen className="w-6 h-6" /> <span>BookVerse</span> </div>

    <nav className="hidden md:flex items-center gap-6 text-sm text-neutral-300">
      <a href="#" className="hover:text-white transition">Explore</a>
      <a href="#" className="hover:text-white transition">Categories</a>
      <a href="#" className="hover:text-white transition">My Library</a>
      <a href="#" className="hover:text-white transition">Publish</a>
    </nav>

    <div className="flex items-center gap-3">
      <button className="hidden md:flex border border-neutral-700 px-4 py-2 rounded-xl hover:bg-neutral-800 transition">
        Login
      </button>
      <Menu className="md:hidden" />
    </div>
  </header>

    <section className="px-6 py-20 text-center max-w-4xl mx-auto">
      <motion.h1
        initial={{ opacity: 0, y: 20 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 0.6 }}
        className="text-4xl md:text-6xl font-bold leading-tight"
      >
        Discover. Read. Publish.
      </motion.h1>
      <p className="mt-6 text-neutral-400 text-base md:text-lg">
        A modern platform for readers and authors. Minimal design. Maximum experience.
      </p>

      <div className="mt-8 flex items-center justify-center gap-2 max-w-xl mx-auto">
        <input
          placeholder="Search books..."
          className="w-full bg-neutral-900 border border-neutral-700 px-4 py-3 rounded-xl text-white outline-none"
        />
        <button className="bg-white text-black px-4 py-3 rounded-xl hover:bg-neutral-200 transition">
          <Search className="w-4 h-4" />
        </button>
      </div>
    </section>

    <section className="px-6 pb-20 max-w-6xl mx-auto">
      <h2 className="text-2xl font-semibold mb-8">Trending Books</h2>

      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
        {books.map((book) => (
          <motion.div
            key={book.id}
            whileHover={{ scale: 1.03 }}
            transition={{ type: "spring", stiffness: 200 }}
            className="bg-neutral-900 border border-neutral-800 rounded-2xl p-6 shadow-lg hover:shadow-2xl transition"
          >
            <div className="h-40 bg-neutral-800 rounded-xl mb-4" />
            <h3 className="text-lg font-medium">{book.title}</h3>
            <p className="text-sm text-neutral-400 mt-1">{book.author}</p>
            <button className="mt-4 w-full bg-white text-black py-2 rounded-xl hover:bg-neutral-200 transition">
              Read
            </button>
          </motion.div>
        ))}
      </div>
      </section>
      
    <section className="px-6 py-20 border-t border-neutral-800 text-center">
      <h2 className="text-3xl font-semibold">Start Publishing Today</h2>
      <p className="mt-4 text-neutral-400 max-w-xl mx-auto">
        Share your stories with the world. Build your audience. Monetize your creativity.
      </p>
      <button className="mt-8 bg-white text-black px-8 py-3 rounded-2xl hover:bg-neutral-200 transition">
        Create Account
      </button>
    </section>

    <footer className="px-6 py-10 border-t border-neutral-800 text-sm text-neutral-500 text-center">
      © {new Date().getFullYear()} BookVerse. All rights reserved.
    </footer>
  </div>

  );
}