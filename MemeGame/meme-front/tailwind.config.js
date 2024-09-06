/** @type {import('tailwindcss').Config} */
export default {
    content: ["./index.html", "./src/**/*.{js,ts,jsx,tsx}"],
    theme: {
        extend: {
            fontFamily: {
                boom: ["Boom", "sans-serif"],
            },
            fontSize: {
                big: "calc(50px + 3.5vw)",
            },
            width: {
                main: "calc(200px + 15vw)",
            },
            colors: {
                pinks: "rgb(229, 126, 250)",
                pinker: "rgb(224, 113, 246)",
                violets: "rgb(101, 1, 121)",
                violeter: "rgb(54, 0, 65)",
                darker: "rgb(22, 6, 45)",
            },
            borderRadius: {
                main: "77px",
            },
            boxShadow: {
                normal: "0 0 3px #1670BE",
            },
        },
    },
    plugins: [],
};
