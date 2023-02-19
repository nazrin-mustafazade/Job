/** @@type {import('tailwindcss').Config} */
const colors = require('@tailwindcss/colors')

module.exports = {

    content: [
        "./node_modules/flowbite/**/*.js"
    ],
    // ...
    theme: {
        extend: {
            colors: {
                teal: colors.teal,
                cyan: colors.cyan
            },
        },
    },
    plugins: [
        require('flowbite/plugin'),
        require('@tailwindcss/forms'),
        require('@tailwindcss/aspect-ratio')
    ]
}

