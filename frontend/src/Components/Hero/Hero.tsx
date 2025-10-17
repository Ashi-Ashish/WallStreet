import hero from "../../Assets/Hero.avif";
import { Link } from "react-router-dom";

interface Props { }

const Hero = (props: Props) => {
  return (
    <section id="hero">
      <div className="mx-auto p-8 flex flex-col-reverse lg:flex-row max-w-screen-xl">
        <div className="flex flex-col space-y-10 mb-44 m-10 lg:m-10 xl:m-20 lg:mt-16 lg:w-1/2 xl:mb-52">
          <h1 className="text-5xl font-bold text-center lg:text-6xl lg:max-w-md lg:text-left">
            Financial data with no news.
          </h1>
          <p className="text-2xl text-center text-gray-400 lg:max-w-md lg:text-left">
            Search relevant financial documents without fear mongering and fake
            news.
          </p>
          <div className="mx-auto lg:mx-0">
            <Link
              to="/search"
              className="px-10 py-5 text-2xl font-bold text-white bg-light-green rounded hover:opacity-70 lg:py-4"
            >
              Get Started
            </Link>
          </div>
        </div>
        <div className="mb-24 mx-auto md:w-180 md:px-10 lg:mb-0 lg:w-1/2">
          <img src={hero} alt="Hero illustration" />
        </div>
      </div>
    </section>
  );
};

export default Hero;
