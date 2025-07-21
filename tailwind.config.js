/** @type {import('tailwindcss').Config} */
module.exports = {
  darkMode: 'media',
  content: [
    "./Views/**/*.cshtml",
    "./Pages/**/*.cshtml",
    "./wwwroot/js/**/*.js",
    "./**/*.razor",
    // add other paths where you use Tailwind classes
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};
