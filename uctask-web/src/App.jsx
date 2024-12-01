import { LogInIcon } from "lucide-react";
import { Button } from "./components/ui/button";
import Emoji from "./components/asset/Emoji";

function App() {
    return (
        <div className="max-w-7xl m-auto">
            <nav className="px-10 py-4 flex justify-between items-center">
                <div>
                    <h1 className="text-3xl font-bold tracking-tighter">
                        UC Task
                    </h1>
                </div>
                <div className="flex space-x-2 items-center">
                    <Button variant="outline">
                        <span>Register</span>
                    </Button>
                    <Button className="group">
                        <LogInIcon className="h-4 w-4 mr-2 group-hover:translate-x-2 transition ease-in-out duration-300" />
                        <span>Login</span>
                    </Button>
                </div>
            </nav>
            <main>
                <section className="flex flex-col space-y-5 text-center justify-center items-center py-64">
                    <h1 className="text-6xl font-extrabold tracking-tighter">
                        Keep track of your life!
                    </h1>
                    <h2 className="text-muted-foreground text-justify text-xl font-light">
                        Lorem ipsum dolor sit amet consectetur adipisicing elit.
                        Enim, consectetur dolor quia odit assumenda eligendi!
                    </h2>
                    <h4 className="text-sm w-1/2 text-center">
                        Lorem ipsum dolor sit, amet consectetur adipisicing
                        elit. Tempore at sint, numquam nemo vel harum cum
                        voluptatem eius fugiat eaque perferendis praesentium
                        suscipit in quibusdam unde delectus nulla esse
                        inventore!
                    </h4>
                    <Button
                        className="rounded-full hover:scale-110 transition ease-in-out duration-300 hover:shadow-lg"
                        size="lg"
                    >
                        Start Tracking
                    </Button>
                </section>
            </main>
            <footer className="font-mono text-sm px-10 py-4 text-muted-foreground flex items-center w-full justify-between">
                <div>
                    <span>UC Task &copy; {new Date().getFullYear()}</span>
                </div>
                <div className="flex space-x-2 items-center">
                    <span>Developed with</span>
                    <Emoji
                        lable="love"
                        symbol="❤️"
                    />
                    <span>by</span>
                    <span>
                        <a
                            href="https://x.com/pratikstemkar"
                            target="_blank"
                            className="underline underline-offset-4 hover:text-primary"
                        >
                            Pratik Temkar
                        </a>
                    </span>
                </div>
            </footer>
        </div>
    );
}

export default App;
