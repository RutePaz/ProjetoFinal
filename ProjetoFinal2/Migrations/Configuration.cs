namespace ProjetoFinal2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TI2PFINAL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoFinal2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProjetoFinal2.Models.ApplicationDbContext context)
        {
            try
            {

                //*********************************************************************
                // add Users
                var user = new List<User> {
                      new User {ID_User=1,Username="LiletteThorne",Email="l.thorne@gmail.com"},
                      new User {ID_User=2,Username="RobertStrickland",Email="robertms@hotmail.com"},
                      new User {ID_User=3,Username="SimonEvers",Email="simon_evers@gamil.com"},
                      new User {ID_User=4,Username="JoshWolf",Email="josh.wolf@gmail.com"},
                      new User {ID_User=5,Username="AnnabelleHallowell",Email="annahallowell@hotmail.com"},
                      new User {ID_User=6,Username="JeremySaunders",Email="jeremy.p.saunders@gmail.com"}

                    };

                user.ForEach(uu => context.User.AddOrUpdate(u => u.Username, uu));
                context.SaveChanges();


                // add Musicals
                var musical = new List<Musical> {
 new Musical {ID_Musical=1, Title="The Lion King", Synopsis="A lively stage adaptation of the Academy Award-winning 1994 Disney film, The Lion King is the story of a young lion prince living in the flourishing African Pride Lands. Born into the royal family, precocious cub Simba spends his days exploring the sprawling savanna grasslands and idolizing his kingly father, Mufasa, while youthfully shirking the responsibility his position in life requires. When an unthinkable tragedy, orchestrated by Simba’s wicked uncle, Scar, takes his father’s life, Simba flees the Pride Lands, leaving his loss and the life he knew behind. Eventually companioned by two hilarious and unlikely friends, Simba starts anew. But when weight of responsibility and a desperate plea from the now ravaged Pride Lands come to find the adult prince, Simba must take on a formidable enemy, and fulfill his destiny to be king. A vibrant and exciting tale from the great creatives at Disney, The Lion King is a story of love and redemption that nobody should miss.",  Director="Julie Taymor", Duration=150, OpeningNight=new DateTime(2018,10,15), Ticket="from 106.00$",Poster="TheLionKing.jpg"},

  new Musical {ID_Musical=2, Title="Wicked",  Synopsis="Wicked, the Broadway sensation, looks at what happened in the Land of Oz…but from a different angle. Long before Dorothy arrives, there is another girl, born with emerald-green skin—smart, fiery, misunderstood, and possessing an extraordinary talent. When she meets a bubbly blonde who is exceptionally popular, their initial rivalry turns into the unlikeliest of friendships…until the world decides to call one “good,” and the other one “wicked.” With a thrilling score that includes the hits “Defying Gravity,” “Popular” and “For Good,” Wicked has been hailed by The New York Times as “the defining musical of the decade.” Time Magazine cheers, “if every musical had the brain, the heart, and the courage of Wicked, Broadway really would be a magical place.” The Gershwin Theatre on 50th Street and Broadway is that magical place. From the first electrifying note to the final breathtaking moment, Wicked—the untold true story of the Witches of Oz—transfixes audiences with its wildly inventive story. It will send your spirits soaring to heights you’ll never forget.",  Director="Joe Mantello", Duration=165, OpeningNight= new DateTime(2018,10,30), Ticket="from 89.00",Poster="Wicked.jpg"},

  new Musical {ID_Musical=3, Title="A Bronx Tale",  Synopsis="A Bronx Tale is a streetwise musical that takes you to the stoops of the Bronx in the 1960s—where a young man is caught between the father he loves and the mob boss he’d love to be. Featuring a doo-wop score, A Bronx Tale is a story about respect, loyalty, love, and above all else: family.",Director="Robert De Niro and Jerry Zaks", Duration=130, OpeningNight=new DateTime(2019,12,1), Ticket="from 29.00$",Poster="ABronxTale.jpg"},

  new Musical {ID_Musical=4, Title="Dear Evan Hansen", Synopsis="A letter that was never meant to be seen, a lie that was never meant to be told, a life he never dreamed he could have. Evan Hansen is about to get the one thing he’s always wanted: A chance to finally fit in. Both deeply personal and profoundly contemporary, Dear Evan Hansen is the new American musical about life and the way we live it. Dear Evan Hansen has struck a remarkable chord with audiences and critics everywhere.",Director="Michael Greif", Duration=150, OpeningNight=new DateTime(2018,12,04), Ticket="from 119.50$",Poster="DearEvanHansen.jpg"},


  new Musical {ID_Musical=5, Title="Spring Awakening", Synopsis="Based on Frank Wedekind's play of the same name, Spring Awakening depicts a dozen young people making their way through the thrilling, complicated and mysterious time of sexual awakening.", Director="Michael Mayer", Duration=140, OpeningNight=new DateTime(2018,11,16),Ticket="from 85.00$", Poster="SpringAwakening.jpg"},

  new Musical {ID_Musical=6, Title="Cats",  Synopsis="Based on TS Eliot's Old Possum's Book of Practical Cats, this musical tells the story of the Jellicle cats and each cat's individual quest to be selected as the one lucky cat that will ascend to the heavyside layer. In their desire to be chosen to rise above to cat heaven, each cat sings their story and tells their unique 'tail.'", Director="Trevor Nunn", Duration=150, OpeningNight=new DateTime(2018,10,30), Ticket="from 130.00$", Poster="Cats.jpg"},

  new Musical {ID_Musical=7, Title="The Book Of Mormon",  Synopsis="The Book of Mormon follows two young missionaries who are sent to Uganda to try to convert citizens to the Mormon religion. One missionary, Elder Price, is an enthusiastic go-getter with a strong dedication to his faith, while his partner, Elder Cunningham, is a socially awkward but well meaning nerd whose tendency to embroider the truth soon lands him in trouble. Upon their arrival in Africa, Elders Price and Cunningham learn that in a society plagued by AIDS, poverty and violence, a successful mission may not be as easy as they expected.", Director="Casey Nicholaw and Trey Parker", Duration=150, OpeningNight=new DateTime(2019,03,24),Ticket="from 69.00", Poster="TheBookOfMormon.jpg"},

  new Musical {ID_Musical=8, Title="West Side Story",  Synopsis="Pulled directly from the pages of Shakespeare's Romeo and Juliet, the musical takes place on New York's West Side in the mid-1950s amidst widespread racial and social tension. The show begins as a war is building between two rival gangs fighting over the same piece of turf: born and bred New York boys, The Jets, and Puerto Rican immigrants The Sharks. In the midst of the battlefield are two young romantics, good-boy Tony, a Jet ready to leave the gang life behind, and wide-eyed Maria, the sister of Sharks leader, Bernardo. When Tony and Maria unexpectedly meet and fall for one another, tension between the rival groups only escalates, leading to a bloody and senseless rumble that costs both sides young lives. In spite of the violence, the true story at the core of the show is two lovers trying to find a way to be together—and whether either can survive when hate and ignorance are unwilling to yield.", Director="Gerald Freedman", Duration=160, OpeningNight=new DateTime(2018,03,19), Ticket="from 120.00$",Poster="WestSideStory.jpg"},


  new Musical {ID_Musical=9, Title="Guys And Dolls",  Synopsis="Set in Depression-era Times Square, Guys and Dolls is about a couple of big city gamblers and the women who love them. It tells the overlapping stories of high-roller Sky Masterson, who falls in love with mission worker Sarah Brown, and lovable rapscallion Nathan Detroit, engaged for 14 years to Miss Adelaide, a headliner at the Hot Box Club. Nathan runs a famous floating crap game, and an ongoing plot line involves his quest for a safe place for the game as Adelaide continues her quest to convince him to marry her. Meanwhile, Sarah, mistakenly believing that Sky set up an illegal game at the mission, tries to fight her affection for the charismatic crapshooter.", Director="Joseph L. Mankiewicz", Duration=150, OpeningNight=new DateTime(2019,04,29), Ticket="from 130.00$",Poster="GuysAandDolls.jpg"},


  new Musical {ID_Musical=10, Title="Hamilton",  Synopsis="Hamilton is the story of the unlikely Founding Father determined to make his mark on the new nation as hungry and ambitious as he is. From bastard orphan to Washington's right-hand man, rebel to war hero, a loving husband caught in the country's first sex scandal, to the Treasury head who made an untrusting world believe in the American economy. George Washington, Eliza Hamilton, Thomas Jefferson and Hamilton's lifelong friend/foil Aaron Burr all make their mark in this astonishing new musical exploration of a political mastermind.", Director="Thomas Kail", Duration=175, OpeningNight=new DateTime(2018,08,06), Ticket="from 199.00$",Poster="Hamilton.jpg"}
};
                musical.ForEach(mm => context.Musical.AddOrUpdate(m => m.Title, mm));
                context.SaveChanges();
                //*********************************************************************
                // add Cast
                var Actor = new List<Cast> {

  new Cast {ID_Actor=1, Name="Dashaun Young",Image="DashaunYoung.jpg"},
  new Cast {ID_Actor=2, Name="L. Steven Taylor",Image="L.StevenTaylor.jpg"},
  new Cast {ID_Actor=3, Name="Adrienne Walker",Image="AdrienneWalker.jpg"},
  new Cast {ID_Actor=4, Name="Tshidi Manye",Image="TshidiManye.jpg"},
  new Cast {ID_Actor=5, Name="Jordan Toure",Image="JordanToure.jpg"},
  new Cast {ID_Actor=6, Name="Stephen Carlile",Image="StephenCarlile.jpg"},
  new Cast {ID_Actor=7, Name="Aliyah Mastin",Image="AliyahMastin.jpg"},
  new Cast {ID_Actor=8, Name="Cameron Pow",Image="CameronPow.jpg"},
  new Cast {ID_Actor=9, Name="Ben Jeffrey",Image="BenJeffrey.jpg"},
  new Cast {ID_Actor=10, Name="Fred Berman",Image="FredBerman.jpg"},
  new Cast {ID_Actor=11, Name="Bonita J. Hamilton",Image="BonitaJ.Hamilton.jpg"},


  new Cast {ID_Actor=12, Name="Jackie Burns",Image="JackieBurns.jpg"},
  new Cast {ID_Actor=13, Name="Amanda Jane Cooper",Image="AmandaJaneCooper.jpg"},
  new Cast {ID_Actor=14, Name="Ashley Parker Angel",Image="AshleyParkerAngel.jpg"},
  new Cast {ID_Actor=15, Name="P.J. Benjamin",Image="P.J.Benjamin.jpg"},
  new Cast {ID_Actor=16, Name="Kristen Martin",Image="KristenMartin.jpg"},
  new Cast {ID_Actor=17, Name="Isabel Keating",Image="IsabelKeating.jpg"},
  new Cast {ID_Actor=18, Name="Jye Frasca",Image="JyeFrasca.jpg"},
  new Cast {ID_Actor=19, Name="Martin Moran",Image="MartinMoran.jpg"},


  new Cast {ID_Actor=20, Name="Adam Kaplan",Image="AdamKaplan.jpg"},
  new Cast {ID_Actor=21, Name="Richard H. Blake",Image="RichardH.Blake.jpg"},
  new Cast {ID_Actor=22, Name="Nick Cordero",Image="NickCordero.jpg"},
  new Cast {ID_Actor=23, Name="Christiani Pitts",Image="ChristianiPitts.jpg"},
  new Cast {ID_Actor=24, Name="Bradley Gibson",Image="BradleyGibson.jpg"},
  new Cast {ID_Actor=25, Name="Lucia Giannetta",Image="LuciaGiannetta.jpg"},
  new Cast {ID_Actor=26, Name="Will Coombs",Image="WillCoombs.jpg"},



  new Cast {ID_Actor=27, Name="Taylor Trensch",Image="TaylorTrensch.jpg" },
  new Cast {ID_Actor=28, Name="Jennifer Laura Thompson",Image="JenniferLauraThompson.jpg"},
  new Cast {ID_Actor=29, Name="Rachel Bay Jones",Image="RachelBayJones.jpg"},
  new Cast {ID_Actor=30, Name="Michael Park",Image="MichaelPark.jpg"},
  new Cast {ID_Actor=31, Name="Laura Dreyfuss",Image="LauraDreyfuss.jpg"},
  new Cast {ID_Actor=32, Name="Mike Faist",Image="MikeFaist.jpg"},
  new Cast {ID_Actor=33, Name="Will Roland",Image="WillRoland.jpg"},
  new Cast {ID_Actor=34, Name="Phoenix Best",Image="PhoenixBest.jpg"},



  new Cast {ID_Actor=35, Name="Jonathan Groff ",Image="JonathanGroff.jpg"},
  new Cast {ID_Actor=36, Name=" Lea Michele",Image="LeaMichele.jpg"},
  new Cast {ID_Actor=37, Name="John Gallagher Jr.",Image="JohnGallagherJr.jpg"},
  new Cast {ID_Actor=38, Name="Stephen Spinella ",Image="StephenSpinella.jpg"},
  new Cast {ID_Actor=39, Name="Christine Estabrook",Image="ChristineEstabrook.jpg"},
  new Cast {ID_Actor=40, Name="Lauren Pritchard",Image="LaurenPritchard.jpg"},
  new Cast {ID_Actor=41, Name="Skylar Astin",Image="SkylarAstin.jpg"},
  new Cast {ID_Actor=42, Name="Lilli Cooper",Image="LilliCooper.jpg"},
  new Cast {ID_Actor=43, Name="Gideon Glick",Image="GideonGlick.jpg"},
  new Cast {ID_Actor=44, Name="Brian Charles Johnson",Image="BrianCharlesJohnson.jpg"},
  new Cast {ID_Actor=45, Name="Phoebe Strole",Image="PhoebeStrole.jpg"},
  new Cast {ID_Actor=46, Name="Jonathan B. Wright",Image="JonathanB.Wright.jpg"},
  new Cast {ID_Actor=47,Name="Remy Zaken",Image="RemyZaken.jpg"},



  new Cast {ID_Actor=48, Name="Robin Lake",Image="RobinLake.jpg"},
  new Cast {ID_Actor=49, Name="Dean Ambrose",Image="DeanAmbrose.jpg"},
  new Cast {ID_Actor=50, Name="Rory Furkey King",Image="RoryFurkeyKing.jpg"},
  new Cast {ID_Actor=51, Name="Tony McGill",Image="TonyMcGill.jpg"},
  new Cast {ID_Actor=52, Name="Bruce Aguilar-Rohan",Image="BruceAguilarRohan.jpg"},
  new Cast {ID_Actor=53, Name="Nell Martin",Image="NellMartin.jpg"},
  new Cast {ID_Actor=54, Name="Fletcher Dobinson",Image="FletcherDobinson.jpg"},
  new Cast {ID_Actor=55, Name="Ella Nonini",Image="EllaNonini.jpg"},
  new Cast {ID_Actor=56, Name="Joanna Ampil",Image="JoannaAmpil.jpg"},
  new Cast {ID_Actor=57, Name="Elizabeth Futter",Image="ElizabethFutter.jpg"},
  new Cast {ID_Actor=58, Name="Grace Swaby",Image="GraceSwaby.jpg"},



  new Cast {ID_Actor=59, Name="Dave Thomas Brown",Image="DaveThomasBrown.jpg"},
  new Cast {ID_Actor=60, Name="Cody Jamison Strand",Image="CodyJamisonStrand.jpg"},
  new Cast {ID_Actor=61, Name="Nikki Renée Daniels",Image="NikkiRenéeDaniels.jpg"},
  new Cast {ID_Actor=62, Name="Stephen Ashfield",Image="StephenAshfield.jpg"},
  new Cast {ID_Actor=63, Name="Billy Eugene Jones",Image="BillyEugeneJones.jpg"},




  new Cast {ID_Actor=64, Name="Mickey Calin ",Image="MickeyCalin.jpg"},
  new Cast {ID_Actor=65, Name="Larry Kert",Image="LarryKert.jpg"},
  new Cast {ID_Actor=66, Name="Carol Lawrence",Image="CarolLawrence.jpg"},
  new Cast {ID_Actor=67, Name="Ken Le Roy ",Image="KenLeRoy.jpg"},
  new Cast {ID_Actor=68, Name="Chita Rivera ",Image="ChitaRivera.jpg"},
  new Cast {ID_Actor=69, Name="Art Smith ",Image="ArtSmith.jpg"},



  new Cast {ID_Actor=70, Name="Robert Alda",Image="RobinAlda.jpg"},
  new Cast {ID_Actor=71, Name="Isabel Bigley",Image="IsabelBigley.jpg"},
  new Cast {ID_Actor=72, Name=" Vivian Blaine ",Image="VivianBlaine.jpg"},
  new Cast {ID_Actor=73, Name="Sam Levene ",Image="SamLevene.jpg"},
  new Cast {ID_Actor=74, Name="Pat Rooney ",Image="PatRooney.jpg"},
  new Cast {ID_Actor=75, Name="B.S. Pully ",Image="BSPully.jpg"},
  new Cast {ID_Actor=76, Name="Tom Pedi ",Image="TomPedi.jpg"},
  new Cast {ID_Actor=77, Name="Stubby Kaye ",Image="StubbyKaye.jpg"},



  new Cast {ID_Actor=78, Name="Lin-Manuel Miranda",Image="LinManuelMiranda.jpg"},
  new Cast {ID_Actor=79, Name="Leslie Odom, Jr.",Image="LeslieOdom Jr.jpg"},
  new Cast {ID_Actor=80, Name="Phillipa Soo",Image="PhillipaSoo.jpg"},
  new Cast {ID_Actor=81, Name="Renée Elise Goldsberry",Image="RenéeEliseGoldsberry.jpg"},
  new Cast {ID_Actor=82, Name="Daveed Diggs",Image="DaveedDiggs.jpg"},
  new Cast {ID_Actor=83, Name="Christopher Jackson",Image="ChristopherJackson.jpg"},
  new Cast {ID_Actor=84, Name="Brian d'Arcy James",Image="BriandArcyJames.jpg"},
  new Cast {ID_Actor=85, Name="Anthony Ramos",Image="AnthonyRamos.jpg"},
  new Cast {ID_Actor=86, Name="Jasmine Cephas Jones",Image="JasmineCephasJones.jpg"}
};
                Actor.ForEach(aa => context.Actor.AddOrUpdate(a => a.Name, aa));
                context.SaveChanges();


                //*********************************************************************
                // add Reviews
                var reviews = new List<Reviews> {
  new Reviews {ID_Review=1, Review="The breathtakingly staged Broadway adaptation of Disney's king of the cartoon jungle is an instant theater classic.",MusicalFK=1, UserFK=1},
  new Reviews {ID_Review=2, Review="Awe-inspiring! Broadway theater is alive again. [Julie] Taymor's imaginative ideas seem limitless. it's a gorgeous, gasp-inducing spectacle. Most important - against all odds - it has innocence. The show appeals to our primal, childlike excitement in the power of theater to make us see things afresh.",MusicalFK=1,UserFK=4},

  new Reviews {ID_Review=4, Review="The most complete, and completely satisfying, musical I've come across in a long time.",MusicalFK=2,UserFK=3},
  new Reviews {ID_Review=5, Review="Winnie Holzman's script keeps the gags coming as it cleverly subverts the film that spawned it. Packed with spectacular coups de theatre and magical effects.",MusicalFK=2,UserFK=2},

  new Reviews {ID_Review=6, Review="A combination of Jersey Boys and West Side Story.",MusicalFK=3,UserFK=5},
  new Reviews {ID_Review=7, Review=" The kind of tale that makes you laugh & cry.",MusicalFK=3,UserFK=5},

  new Reviews {ID_Review=8, Review="Instantly pierces your heart and burrows into your consciousness.",MusicalFK=4,UserFK=6},
  new Reviews {ID_Review=9, Review="A dazzling reminder of the power of live theater! A Broadway star is born!",MusicalFK=4,UserFK=4},

  new Reviews {ID_Review=10, Review="Imprinted on the memory is the happy sensation of having witnessed something unusual ans aspiring, something vital and new",MusicalFK=5,UserFK=1},
  new Reviews {ID_Review=11, Review="The singing throughout is impassioned and affecting, giving powerful voice to the blend of melancholy and hope in the Songs.",MusicalFK=5,UserFK=3},


  new Reviews {ID_Review=12, Review="Is guaranteed to leave you feline groovy—it’s here now, though I wouldn’t bet on it lasting forever.",MusicalFK=6,UserFK=2},


  new Reviews {ID_Review=13, Review="A spectacular, rather perfect Broadway musical not only grounded in a serious love and understanding of the traditions that make a Broadway musical great but also filled with love for the very flawed, mortal characters who populate this romp.",MusicalFK=7,UserFK=6},
  new Reviews {ID_Review=14, Review="Parker and Stone have created one of the freshest original musicals in recent memory. It has tuneful Songs, clever lyrics, winning characters, explosive laughs and disarmingly intimate moments.",MusicalFK=7,UserFK=3},


  new Reviews {ID_Review=15, Review="This fresh, bold production is so exciting it makes you ache with pleasure. It's both airborne and transcendent.",MusicalFK=8,UserFK=5},
  new Reviews {ID_Review=16, Review="Having the Sharks speakin their native tongue is brilliant! The excitement and emotional force of this revival don't need translation. It feels incredibly right for New York to have a story this bittersweet back in Times Square, where is belongs.",MusicalFK=8,UserFK=1},

  new Reviews {ID_Review=17, Review="In all departments 'Guys and Dolls' is a perfect musical comedy.",MusicalFK=9,UserFK=2},
  new Reviews {ID_Review=18, Review="A smart production with a talented Cast and remarkable effects.",MusicalFK=9,UserFK=3},



  new Reviews {ID_Review=19, Review="'Hamilton' is the most exciting and significant musical of the decade. Sensationally potent and theatrically vital, it is plugged straight into the wall socket of contemporary music. This show makes me feel hopeful for the future of musical theater.",MusicalFK=10,UserFK=3},
  new Reviews {ID_Review=20, Review="Historic. 'Hamilton' is brewing up a revolution. This is a show that aims impossibly high and hits its target. It's probably not possible to top the adrenaline rush.",MusicalFK=10,UserFK=1}
};
                reviews.ForEach(rr => context.Reviews.AddOrUpdate(r => r.Review, rr));
                context.SaveChanges();


                //*********************************************************************
                // add Soundtrack
                var Song = new List<Soundtrack> {
  new Soundtrack {ID_Song=1, SongName="Circle of Life", Duration="4:29", MusicalFK=1 },
  new Soundtrack {ID_Song=2, SongName="Grasslands Chant", Duration="2:22", MusicalFK=1},
  new Soundtrack {ID_Song=3, SongName="Morning Report", Duration="2:32", MusicalFK=1},
  new Soundtrack {ID_Song=4, SongName="Lioness Hunt", Duration="2:06", MusicalFK=1},
  new Soundtrack {ID_Song=5, SongName="I Just Can't Wait to Be King", Duration="3:03", MusicalFK=1 },
  new Soundtrack {ID_Song=6, SongName="Chow Down", Duration="3:17", MusicalFK= 1},
  new Soundtrack {ID_Song=7, SongName="They Live in You", Duration="3:03", MusicalFK= 1},
  new Soundtrack {ID_Song=8, SongName="Be Prepared", Duration="3:27", MusicalFK=1 },
  new Soundtrack {ID_Song=9, SongName="Stampede", Duration="2:39", MusicalFK=1 },
  new Soundtrack {ID_Song=10, SongName="Rafiki Mourns", Duration="2:05", MusicalFK=1 },
  new Soundtrack {ID_Song=11, SongName="Hakuna Matata", Duration="3:12", MusicalFK=1},
  new Soundtrack {ID_Song=12, SongName="One by One", Duration="1:53", MusicalFK= 1},
  new Soundtrack {ID_Song=13, SongName="Madness of King Scar", Duration="5:28", MusicalFK=1 },
  new Soundtrack {ID_Song=14, SongName="Shadowland", Duration="4:30", MusicalFK= 1},
  new Soundtrack {ID_Song=15, SongName="Lion Sleeps Tonight", Duration="1:10", MusicalFK=1 },
  new Soundtrack {ID_Song=16, SongName="Endless Night", Duration="4:42", MusicalFK= 1},
  new Soundtrack {ID_Song=17, SongName="Can You Feel the Love Tonight?", Duration="4:59", MusicalFK= 1},
  new Soundtrack {ID_Song=18, SongName="He Lives in You (Reprise)", Duration="4:14", MusicalFK=1 },
  new Soundtrack {ID_Song=19, SongName="Simba Confronts Scar", Duration="2:25", MusicalFK=1},
  new Soundtrack {ID_Song=20, SongName="King of Pride Rock/Circle of Life (Reprise)", Duration="3:23", MusicalFK=1 },


  new Soundtrack {ID_Song=21, SongName="No One Mourns the Wicked", Duration="6:41", MusicalFK=2 },
  new Soundtrack {ID_Song=22, SongName="Dear Old Shiz", Duration="1:26", MusicalFK=2 },
  new Soundtrack {ID_Song=23, SongName="The Wizard and I", Duration="5:10", MusicalFK=2 },
  new Soundtrack {ID_Song=24, SongName="What Is This Feeling?", Duration="3:32", MusicalFK=2 },
  new Soundtrack {ID_Song=25, SongName="Something Bad", Duration="1:39", MusicalFK=2 },
  new Soundtrack {ID_Song=26, SongName="Dancing Through Life", Duration="7:37", MusicalFK=2 },
  new Soundtrack {ID_Song=27, SongName="Popular", Duration="3:44", MusicalFK=2 },
  new Soundtrack {ID_Song=28, SongName="I'm Not That Girl", Duration="2:59", MusicalFK=2 },
  new Soundtrack {ID_Song=29, SongName="One Short Day", Duration="3:04", MusicalFK=2 },
  new Soundtrack {ID_Song=30, SongName="A Sentimental Man", Duration="1:16", MusicalFK=2 },
  new Soundtrack {ID_Song=31, SongName="Defying Gravity", Duration="5:54", MusicalFK=2 },
  new Soundtrack {ID_Song=32, SongName="Thank Goodness", Duration="6:23", MusicalFK=2 },
  new Soundtrack {ID_Song=33, SongName="The Wicked Witch of the East", Duration="4:21", MusicalFK=2 },
  new Soundtrack {ID_Song=34, SongName="Wonderful", Duration="4:57", MusicalFK=2 },
  new Soundtrack {ID_Song=35, SongName="I'm Not That Girl (Reprise)", Duration="0:50", MusicalFK=2 },
  new Soundtrack {ID_Song=36, SongName="As Long as You're Mine", Duration="3:46", MusicalFK=2 },
  new Soundtrack {ID_Song=37, SongName="No Good Deed", Duration="3:32", MusicalFK=2 },
  new Soundtrack {ID_Song=38, SongName="March of the Witch Hunters", Duration="1:31", MusicalFK=2 },
  new Soundtrack {ID_Song=39, SongName="For Good", Duration="5:07", MusicalFK=2 },
  new Soundtrack {ID_Song=40, SongName="Finale", Duration="1:42", MusicalFK=2 },


  new Soundtrack {ID_Song=41, SongName="Belmont Avenue", Duration="5:14", MusicalFK=3 },
  new Soundtrack {ID_Song=42, SongName="Look to Your Hear", Duration="2:48", MusicalFK=3 },
  new Soundtrack {ID_Song=43, SongName="Roll 'Em ", Duration="3:10", MusicalFK=3 },
  new Soundtrack {ID_Song=44, SongName="I Like It", Duration="2:34", MusicalFK=3 },
  new Soundtrack {ID_Song=45, SongName="Giving Back the Money ", Duration="2:13", MusicalFK=3 },
  new Soundtrack {ID_Song=46, SongName="I Like It (Reprise)", Duration="2:32", MusicalFK=3 },
  new Soundtrack {ID_Song=47, SongName="Ain't It The Truth ", Duration="3:36", MusicalFK=3 },
  new Soundtrack {ID_Song=48, SongName="Out of Your Head", Duration="3:25", MusicalFK=3 },
  new Soundtrack {ID_Song=49, SongName="Nicky Machiavelli", Duration="3:42", MusicalFK=3 },
  new Soundtrack {ID_Song=50, SongName="These Streets", Duration="3:59", MusicalFK=3 },
  new Soundtrack {ID_Song=51, SongName="Webster Avenue", Duration="2:38", MusicalFK=3 },
  new Soundtrack {ID_Song=52, SongName="Out of Your Head (Reprise)", Duration="1:06", MusicalFK=3 },
  new Soundtrack {ID_Song=53, SongName="One of the Great Ones", Duration="3:52", MusicalFK=3 },
  new Soundtrack {ID_Song=54, SongName="Ain't It The Truth (Reprise)", Duration="1:19", MusicalFK=3 },
  new Soundtrack {ID_Song=55, SongName="Look to Your Heart (Reprise)", Duration="2:23", MusicalFK=3 },
  new Soundtrack {ID_Song=56, SongName="One of the Great Ones (Reprise)", Duration="0:38", MusicalFK=3 },
  new Soundtrack {ID_Song=57, SongName="Hurt Someone", Duration="4:26", MusicalFK=3 },
  new Soundtrack {ID_Song=58, SongName="In a World Like This", Duration="3:16", MusicalFK=3 },
  new Soundtrack {ID_Song=59, SongName="The Choices We Make ", Duration="5:44", MusicalFK=3 },




  new Soundtrack {ID_Song=60, SongName="Anybody Have a Map?", Duration="2:27", MusicalFK=4 },
  new Soundtrack {ID_Song=61, SongName="Waving Through a Window", Duration="3:56", MusicalFK=4 },
  new Soundtrack {ID_Song=62, SongName="For Forever", Duration="5:01", MusicalFK=4 },
  new Soundtrack {ID_Song=63, SongName="Sincerely, Me", Duration="3:43", MusicalFK=4 },
  new Soundtrack {ID_Song=64, SongName="Requiem", Duration="4:20", MusicalFK=4 },
  new Soundtrack {ID_Song=65, SongName="If I Could Tell Her", Duration="4:09", MusicalFK=4 },
  new Soundtrack {ID_Song=66, SongName="Disappear", Duration="4:36", MusicalFK=4 },
  new Soundtrack {ID_Song=67, SongName="You Will Be Found", Duration="6:01", MusicalFK=4 },
  new Soundtrack {ID_Song=68, SongName="To Break In A Glove", Duration="3:51", MusicalFK=4 },
  new Soundtrack {ID_Song=69, SongName="Only Us", Duration="3:47", MusicalFK=4 },
  new Soundtrack {ID_Song=70, SongName="Good For You", Duration="3:05", MusicalFK=4 },
  new Soundtrack {ID_Song=71, SongName="Words Fail", Duration="5:52", MusicalFK=4 },
  new Soundtrack {ID_Song=72, SongName="So Big/So Small", Duration="4:12", MusicalFK=4 },
  new Soundtrack {ID_Song=73, SongName="Finale", Duration="1:36", MusicalFK=4 },


  new Soundtrack {ID_Song=74, SongName="Mamma Who Bore Me", Duration="2:21", MusicalFK=5 },
  new Soundtrack {ID_Song=75, SongName="Mamma Who Bore Me (Reprise)", Duration="1:16", MusicalFK=5 },
  new Soundtrack {ID_Song=76, SongName="All That's Known", Duration="2:02", MusicalFK=5 },
  new Soundtrack {ID_Song=77, SongName="The Bitch of Living", Duration="2:52", MusicalFK=5 },
  new Soundtrack {ID_Song=78, SongName="My Junk", Duration="2:26", MusicalFK=5 },
  new Soundtrack {ID_Song=79, SongName="Touch Me", Duration="4:31", MusicalFK=5 },
  new Soundtrack {ID_Song=80, SongName="The Word of Your Body", Duration="2:59", MusicalFK=5 },
  new Soundtrack {ID_Song=81, SongName="The Dark I Know Well", Duration="3:05", MusicalFK=5 },
  new Soundtrack {ID_Song=82, SongName="And Then There Were None", Duration="4:16", MusicalFK=5 },
  new Soundtrack {ID_Song=83, SongName="The Mirror-Blue Night", Duration="2:23", MusicalFK=5 },
  new Soundtrack {ID_Song=84, SongName="I Believe", Duration="2:31", MusicalFK=5 },
  new Soundtrack {ID_Song=85, SongName="The Guilty Ones", Duration="3:32", MusicalFK=5 },
  new Soundtrack {ID_Song=86, SongName="Don't Do Sadness / Blue Wind", Duration="5:05", MusicalFK=5 },
  new Soundtrack {ID_Song=87, SongName="Left Behind", Duration="4:17", MusicalFK=5 },
  new Soundtrack {ID_Song=88, SongName="Totally Fucked", Duration="3:18", MusicalFK=5 },
  new Soundtrack {ID_Song=89, SongName="The Word of Your Body (Reprise)", Duration="3:10", MusicalFK=5 },
  new Soundtrack {ID_Song=90, SongName="Whispering", Duration="3:35", MusicalFK=5 },
  new Soundtrack {ID_Song=91, SongName="Those You've Known", Duration="4:29", MusicalFK=5 },
  new Soundtrack {ID_Song=92, SongName="The Soundtrack of Purple Summer", Duration="3:29", MusicalFK=5 },



  new Soundtrack {ID_Song=93, SongName="Overture", Duration="2:28", MusicalFK=6 },
  new Soundtrack {ID_Song=94, SongName="Prologue: Jellicle Songs for Jellicle Cats", Duration="5:39", MusicalFK=6 },
  new Soundtrack {ID_Song=95, SongName="Naming of Cats", Duration="2:19", MusicalFK=6 },
  new Soundtrack {ID_Song=96, SongName="Invitation to the Jellicle Ball", Duration="2:14", MusicalFK=6 },
  new Soundtrack {ID_Song=97, SongName="Old Gumbie Cat", Duration="5:16", MusicalFK=6 },
  new Soundtrack {ID_Song=98, SongName="Rum Tum Tugger", Duration="3:06", MusicalFK=6 },
  new Soundtrack {ID_Song=99, SongName="Grizabella: The Glamour Cat", Duration="3:02", MusicalFK=6 },
  new Soundtrack {ID_Song=100, SongName="Bustopher Jones", Duration="4:22", MusicalFK=6 },
  new Soundtrack {ID_Song=101, SongName="Mungojerrie and Rumpelteazer", Duration="3:50", MusicalFK=6 },
  new Soundtrack {ID_Song=102, SongName="Old Deuteronomy", Duration="4:52", MusicalFK=6 },
  new Soundtrack {ID_Song=103, SongName="Jellicle Ball", Duration="7:14", MusicalFK=6 },
  new Soundtrack {ID_Song=104, SongName="Memory", Duration="1:24", MusicalFK=6 },
  new Soundtrack {ID_Song=105, SongName="Moments of Happiness", Duration="3:13", MusicalFK=6 },
  new Soundtrack {ID_Song=106, SongName="Gus: The Theatre Cat", Duration="6:42", MusicalFK=6 },
  new Soundtrack {ID_Song=107, SongName="Growltiger's Last Stand", Duration="9:40", MusicalFK=6 },
  new Soundtrack {ID_Song=108, SongName="Skimbleshanks: The Railway Cat", Duration="4:46", MusicalFK=6 },
  new Soundtrack {ID_Song=109, SongName="Macavity: The Mystery Cat", Duration="6:58", MusicalFK=6 },
  new Soundtrack {ID_Song=110, SongName="Mr. Mistoffelees", Duration="3:38", MusicalFK=6 },
  new Soundtrack {ID_Song=112, SongName="Journey to the Heaviside Layer", Duration="1:54", MusicalFK=6 },
  new Soundtrack {ID_Song=113, SongName="Ad-Dressing of Cats", Duration="5:20", MusicalFK=6 },



  new Soundtrack {ID_Song=114, SongName="Hello!", Duration="2:52", MusicalFK=7 },
  new Soundtrack {ID_Song=115, SongName="Two By Two", Duration="4:31", MusicalFK=7 },
  new Soundtrack {ID_Song=115, SongName="You And Me (But Mostly Me)", Duration="2:43", MusicalFK=7 },
  new Soundtrack {ID_Song=116, SongName="Hasa Diga Eebowai", Duration="4:24", MusicalFK=7 },
  new Soundtrack {ID_Song=117, SongName="Turn It Off", Duration="5:03", MusicalFK=7 },
  new Soundtrack {ID_Song=118, SongName="I Am Here For You", Duration="2:04", MusicalFK=7 },
  new Soundtrack {ID_Song=119, SongName="All-American Prophet", Duration="6:15", MusicalFK=7 },
  new Soundtrack {ID_Song=120, SongName="Sal Tlay Ka Siti", Duration="3:42", MusicalFK=7 },
  new Soundtrack {ID_Song=121, SongName="Man Up", Duration="4:04", MusicalFK=7 },
  new Soundtrack {ID_Song=122, SongName="Making Things Up Again", Duration="4:16", MusicalFK=7 },
  new Soundtrack {ID_Song=123, SongName="Spooky Mormon Hell Dream", Duration="4:30", MusicalFK=7 },
  new Soundtrack {ID_Song=124, SongName="I Believe", Duration="4:42", MusicalFK=7 },
  new Soundtrack {ID_Song=125, SongName="Baptize Me", Duration="4:15", MusicalFK=7 },
  new Soundtrack {ID_Song=126, SongName="I Am Africa", Duration="2:21", MusicalFK=7 },
  new Soundtrack {ID_Song=127, SongName="Joseph Smith American Moses", Duration="6:12", MusicalFK=7 },
  new Soundtrack {ID_Song=128, SongName="Tomorrow Is A Latter Day", Duration="6:02", MusicalFK=7 },




  new Soundtrack {ID_Song=129, SongName="Prologue", Duration="4:09", MusicalFK=8 },
  new Soundtrack {ID_Song=130, SongName="Overture", Duration="2:07", MusicalFK=8 },
  new Soundtrack {ID_Song=131, SongName="Jet Soundtrack", Duration="2:17", MusicalFK=8 },
  new Soundtrack {ID_Song=132, SongName="Something's Coming", Duration="6:26", MusicalFK=8 },
  new Soundtrack {ID_Song=133, SongName="Dance at the Gym", Duration="3:02", MusicalFK=8 },
  new Soundtrack {ID_Song=134, SongName="Maria", Duration="3:02", MusicalFK=8 },
  new Soundtrack {ID_Song=135, SongName="America", Duration="4:43", MusicalFK=8 },
  new Soundtrack {ID_Song=136, SongName="Cool", Duration="4:32", MusicalFK=8 },
  new Soundtrack {ID_Song=137, SongName="One Hand, One Heart", Duration="4:07", MusicalFK=8 },
  new Soundtrack {ID_Song=138, SongName="Tonight (quintet)", Duration="5:34", MusicalFK=8 },
  new Soundtrack {ID_Song=139, SongName="Rumble", Duration="3:22", MusicalFK=8 },
  new Soundtrack {ID_Song=140, SongName="I Feel Pretty", Duration="3:25", MusicalFK=8 },
  new Soundtrack {ID_Song=141, SongName="Somewhere", Duration="6:50", MusicalFK=8 },
  new Soundtrack {ID_Song=142, SongName="Gee, Officer Krupke!", Duration="4:13", MusicalFK=8 },
  new Soundtrack {ID_Song=143, SongName="A Boy Like That/I Have a Love", Duration="5:29", MusicalFK=8 },
  new Soundtrack {ID_Song=144, SongName="Finale", Duration="1:05", MusicalFK=8 },



  new Soundtrack {ID_Song=145, SongName="Runyonland", Duration="2:57", MusicalFK=9 },
  new Soundtrack {ID_Song=146, SongName="Fugue for the Tinhorns", Duration="1:27", MusicalFK=9 },
  new Soundtrack {ID_Song=147, SongName="Follow the Fold", Duration="1:17", MusicalFK=9 },
  new Soundtrack {ID_Song=148, SongName="The Oldest Established", Duration="2:35", MusicalFK=9 },
  new Soundtrack {ID_Song=149, SongName="I'll Know", Duration="4:56", MusicalFK=9 },
  new Soundtrack {ID_Song=150, SongName="Bushel and a Peck", Duration="3:08", MusicalFK=9 },
  new Soundtrack {ID_Song=151, SongName="Adelaide's Lament", Duration="3:40", MusicalFK=9 },
  new Soundtrack {ID_Song=152, SongName="Guys and Dolls", Duration="2:58", MusicalFK=9 },
  new Soundtrack {ID_Song=153, SongName="Havana", Duration="4:00", MusicalFK=9 },
  new Soundtrack {ID_Song=154, SongName="If I Were a Bell", Duration="2:32", MusicalFK=9 },
  new Soundtrack {ID_Song=155, SongName="My Time of Day", Duration="2:00", MusicalFK=9 },
  new Soundtrack {ID_Song=156, SongName="I've Never Been in Love Before", Duration="2:07", MusicalFK=9 },
  new Soundtrack {ID_Song=157, SongName="Entr'acte; Take Back Your Mink", Duration="5:20", MusicalFK=9 },
  new Soundtrack {ID_Song=158, SongName="Adelaide's Lament (Reprise)", Duration="1:27", MusicalFK=9 },
  new Soundtrack {ID_Song=159, SongName="More I Cannot Wish You", Duration="2:18", MusicalFK=9 },
  new Soundtrack {ID_Song=160, SongName="Crapshooters' Dance", Duration="3:21", MusicalFK=9 },
  new Soundtrack {ID_Song=161, SongName="Luck Be a Lady", Duration="3:02", MusicalFK=9 },
  new Soundtrack {ID_Song=162, SongName="Sue Me", Duration="2:50", MusicalFK=9 },
  new Soundtrack {ID_Song=163, SongName="Sit Down, You're Rockin' the Boat", Duration="2:57", MusicalFK=9 },
  new Soundtrack {ID_Song=164, SongName="Marry the Man Today", Duration="", MusicalFK=9 },
  new Soundtrack {ID_Song=165, SongName="Guys and Dolls (Reprise)", Duration="1:11", MusicalFK=9 },



new Soundtrack {ID_Song=166, SongName="Alexander Hamilton", Duration="3:57", MusicalFK=10 },
  new Soundtrack {ID_Song=167, SongName="Aaron Burr, Sir", Duration="2:37", MusicalFK=10 },
  new Soundtrack {ID_Song=168, SongName="My Shot", Duration="5:33", MusicalFK=10 },
  new Soundtrack {ID_Song=169, SongName="The Story of Tonight", Duration="1:32", MusicalFK=10 },
  new Soundtrack {ID_Song=170, SongName="The Schuyler Sisters", Duration="3:07", MusicalFK=10 },
  new Soundtrack {ID_Song=171, SongName="Farmer Refuted", Duration="1:53", MusicalFK=10 },
  new Soundtrack {ID_Song=172, SongName="You'll Be Back", Duration="3:28", MusicalFK=10 },
  new Soundtrack {ID_Song=173, SongName="Right Hand Man", Duration="5:22", MusicalFK=10 },
  new Soundtrack {ID_Song=174, SongName="A Winter's Ball", Duration="1:10", MusicalFK=10 },
  new Soundtrack {ID_Song=175, SongName="Helpless", Duration="4:10", MusicalFK=10 },
  new Soundtrack {ID_Song=176, SongName="Satisfied", Duration="5:29", MusicalFK=10 },
  new Soundtrack {ID_Song=177, SongName="The Story of Tonight (Reprise)", Duration="1:56", MusicalFK=10 },
  new Soundtrack {ID_Song=178, SongName="Wait For It", Duration="3:14", MusicalFK=10 },
  new Soundtrack {ID_Song=179, SongName="Stay Alive", Duration="2:39", MusicalFK=10 },
  new Soundtrack {ID_Song=180, SongName="Ten Duel Commandments", Duration="1:47", MusicalFK=10 },
  new Soundtrack {ID_Song=181, SongName="Meet Me Inside", Duration="1:24", MusicalFK=10 },
  new Soundtrack {ID_Song=182, SongName="That Would Be Enough", Duration="2:58", MusicalFK=10 },
  new Soundtrack {ID_Song=183, SongName="Guns and Ships", Duration="2:08", MusicalFK=10 },
  new Soundtrack {ID_Song=184, SongName="History Has Its Eye on You", Duration="1:37", MusicalFK=10 },
  new Soundtrack {ID_Song=185, SongName="Yorktown", Duration="4:03", MusicalFK=10 },
  new Soundtrack {ID_Song=186, SongName="What Comes Next?", Duration="1:39", MusicalFK=10 },
  new Soundtrack {ID_Song=187, SongName="Dear Theodosia", Duration="3:04", MusicalFK=10 },
  new Soundtrack {ID_Song=188, SongName="Non-Stop", Duration="6:25", MusicalFK=10 },
  new Soundtrack {ID_Song=189, SongName="What'd I Miss", Duration="3:57", MusicalFK=10 },
  new Soundtrack {ID_Song=190, SongName="Cabinet Battle #1", Duration="3:35", MusicalFK=10 },
  new Soundtrack {ID_Song=191, SongName="Take a Break", Duration="4:46", MusicalFK=10 },
  new Soundtrack {ID_Song=192, SongName="Say No to This", Duration="4:02", MusicalFK=10 },
  new Soundtrack {ID_Song=193, SongName="The Room Where It Happens", Duration="5:18", MusicalFK=10 },
  new Soundtrack {ID_Song=194, SongName="Schuyler Defeated", Duration="1:04", MusicalFK=10 },
  new Soundtrack {ID_Song=195, SongName="Cabinet Battle #2", Duration="2:23", MusicalFK=10 },
  new Soundtrack {ID_Song=196, SongName="Washington on Your Side", Duration="3:01", MusicalFK=10 },
  new Soundtrack {ID_Song=197, SongName="One Last Time", Duration="4:56", MusicalFK=10 },
  new Soundtrack {ID_Song=198, SongName="I Know Him", Duration="1:38", MusicalFK=10 },
  new Soundtrack {ID_Song=199, SongName="The Adams Administration", Duration="0:55", MusicalFK=10 },
  new Soundtrack {ID_Song=200, SongName="We Know", Duration="2:22", MusicalFK=10 },
  new Soundtrack {ID_Song=201, SongName="Hurricane", Duration="2:24", MusicalFK=10 },
  new Soundtrack {ID_Song=202, SongName="The Reynolds Pamphlet", Duration="2:08", MusicalFK=10 },
  new Soundtrack {ID_Song=203, SongName="Burn", Duration="3:45", MusicalFK=10 },
  new Soundtrack {ID_Song=204, SongName="Blow Us All Away", Duration="2:54", MusicalFK=10 },
  new Soundtrack {ID_Song=205, SongName="Stay Alive (Reprise)", Duration="1:52", MusicalFK=10 },
  new Soundtrack {ID_Song=206, SongName="It's Quiet Uptown", Duration="4:30", MusicalFK=10 },
  new Soundtrack {ID_Song=207, SongName="The Election of 1800", Duration="3:58", MusicalFK=10 },
  new Soundtrack {ID_Song=208, SongName="The Obedient Servant", Duration="2:30", MusicalFK=10 },
  new Soundtrack {ID_Song=209, SongName="Best of Wives and Best of Women", Duration="0:48", MusicalFK=10 },
  new Soundtrack {ID_Song=210, SongName="The World Was Wide Enough", Duration="", MusicalFK=10 },
  new Soundtrack {ID_Song=211, SongName="Finale (Who Lives, Who Dies, Who Tells Your Story)", Duration="5:02", MusicalFK=10 }

};
                Song.ForEach(ss => context.Song.AddOrUpdate(m => m.SongName, ss));
                context.SaveChanges();




                //*********************************************************************
                // add CastMusical
                var CastMusical = new List<CastMusical>
            {
               new CastMusical {CastFK=1, MusicalFK=1, Character="Simba" },
               new CastMusical {CastFK=2, MusicalFK=1, Character="Mufasa" },
               new CastMusical {CastFK=3, MusicalFK=1, Character="Nala" },
               new CastMusical {CastFK=4, MusicalFK=1, Character="Rafiki" },
               new CastMusical {CastFK=5, MusicalFK=1, Character="Young Simba" },
               new CastMusical {CastFK=6, MusicalFK=1, Character="Scar" },
               new CastMusical {CastFK=7, MusicalFK=1, Character="Young Nala" },
               new CastMusical {CastFK=8, MusicalFK=1, Character="Zazu" },
               new CastMusical {CastFK=9, MusicalFK=1, Character="Pumbaa" },
               new CastMusical {CastFK=10, MusicalFK=1, Character="Timon" },
               new CastMusical {CastFK=11, MusicalFK=1, Character="Shenzi" },

               new CastMusical {CastFK=12, MusicalFK=2, Character="Elphaba" },
               new CastMusical {CastFK=13, MusicalFK=2, Character="Glinda" },
               new CastMusical {CastFK=14, MusicalFK=2, Character="Fiyero" },
               new CastMusical {CastFK=15, MusicalFK=2, Character="The Wizard" },
               new CastMusical {CastFK=16, MusicalFK=2, Character="Nessarose" },
               new CastMusical {CastFK=17, MusicalFK=2, Character="Madame Morrible" },
               new CastMusical {CastFK=18, MusicalFK=2, Character="Boq" },
               new CastMusical {CastFK=19, MusicalFK=2, Character="Doctor Dillamond" },


                new CastMusical {CastFK=20, MusicalFK=3, Character="Calogero" },
               new CastMusical {CastFK=21, MusicalFK=3, Character="Lorenzo Richard" },
               new CastMusical {CastFK=22, MusicalFK=3, Character="Sonny" },
               new CastMusical {CastFK=23, MusicalFK=3, Character="Jane" },
               new CastMusical {CastFK=24, MusicalFK=3, Character="Tyrone" },
               new CastMusical {CastFK=25, MusicalFK=3, Character="Rosina" },
               new CastMusical {CastFK=26, MusicalFK=3, Character="Young Calogero" },

               new CastMusical {CastFK=27, MusicalFK=4, Character="Evan" },
               new CastMusical {CastFK=28, MusicalFK=4, Character="Cynthia" },
               new CastMusical {CastFK=29, MusicalFK=4, Character="Heidi" },
               new CastMusical {CastFK=30, MusicalFK=4, Character="Larry" },
               new CastMusical {CastFK=31, MusicalFK=4, Character="Zoe" },
               new CastMusical {CastFK=32, MusicalFK=4, Character="Connor" },
               new CastMusical {CastFK=33, MusicalFK=4, Character="Jared" },
               new CastMusical {CastFK=34, MusicalFK=4, Character="Alana" },


                new CastMusical {CastFK=35, MusicalFK=5, Character="Melchior" },
                new CastMusical {CastFK=36, MusicalFK=5, Character="Wendla" },
                new CastMusical {CastFK=37, MusicalFK=5, Character="Moritz" },
                new CastMusical {CastFK=38, MusicalFK=5, Character="Adult Men" },
                new CastMusical {CastFK=39, MusicalFK=5, Character="Adult Women" },
                new CastMusical {CastFK=40, MusicalFK=5, Character="Ilse" },
                new CastMusical {CastFK=41, MusicalFK=5, Character="Georg" },
                new CastMusical {CastFK=42, MusicalFK=5, Character="Martha" },
                new CastMusical {CastFK=43, MusicalFK=5, Character="Ernst" },
                new CastMusical {CastFK=44, MusicalFK=5, Character="Otto" },
                new CastMusical {CastFK=45, MusicalFK=5, Character="Anna" },
                new CastMusical {CastFK=46, MusicalFK=5, Character="Hanschen" },
                new CastMusical {CastFK=47, MusicalFK=5, Character="Thea" },

                new CastMusical {CastFK=48, MusicalFK=6, Character="Alonzo" },
                new CastMusical {CastFK=49, MusicalFK=6, Character="Bill Bailey" },
                new CastMusical {CastFK=50, MusicalFK=6, Character="Bombalurina" },
                new CastMusical {CastFK=51, MusicalFK=6, Character="Gus" },
                new CastMusical {CastFK=52, MusicalFK=6, Character="Carbucketty" },
                new CastMusical {CastFK=53, MusicalFK=6, Character="Cassandra" },
                new CastMusical {CastFK=54, MusicalFK=6, Character="Coricopat" },
                new CastMusical {CastFK=55, MusicalFK=6, Character="Demeter" },
                new CastMusical {CastFK=56, MusicalFK=6, Character="Grizabella" },
                new CastMusical {CastFK=57, MusicalFK=6, Character="Jellylorum" },
                new CastMusical {CastFK=58, MusicalFK=6, Character="Jemima" },


                new CastMusical {CastFK=59, MusicalFK=7, Character="Elder Price" },
                new CastMusical {CastFK=60, MusicalFK=7, Character="Elder Cunningham" },
                new CastMusical {CastFK=61, MusicalFK=7, Character="Nabulungi" },
                new CastMusical {CastFK=62, MusicalFK=7, Character="Elder McKinley" },
                new CastMusical {CastFK=63, MusicalFK=7, Character="Mafala Hatimbi" },


                new CastMusical {CastFK=64, MusicalFK=8, Character="Riff" },
                new CastMusical {CastFK=65, MusicalFK=8, Character="Tony" },
                new CastMusical {CastFK=66, MusicalFK=8, Character="Maria" },
                new CastMusical {CastFK=67, MusicalFK=8, Character="Bernardo" },
                new CastMusical {CastFK=68, MusicalFK=8, Character="Anita" },
                new CastMusical {CastFK=69, MusicalFK=8, Character="Doc" },

                new CastMusical {CastFK=70, MusicalFK=9, Character="Sky Masterson" },
                new CastMusical {CastFK=71, MusicalFK=9, Character="Sarah Brown" },
                new CastMusical {CastFK=72, MusicalFK=9, Character="Miss Adelaide" },
                new CastMusical {CastFK=73, MusicalFK=9, Character="Nathan Detroit" },
                new CastMusical {CastFK=74, MusicalFK=9, Character="Arvide Abernathy" },
                new CastMusical {CastFK=75, MusicalFK=9, Character="Big Jule" },
                new CastMusical {CastFK=76, MusicalFK=9, Character="Harry The Horse" },
                new CastMusical {CastFK=77, MusicalFK=9, Character="Nicely-Nicely Johnson " },

                new CastMusical {CastFK=78, MusicalFK=10, Character="Alexander Hamilton" },
                new CastMusical {CastFK=79, MusicalFK=10, Character="Aaron Burr" },
                new CastMusical {CastFK=80, MusicalFK=10, Character="Eliza Schuyler Hamilton" },
                new CastMusical {CastFK=81, MusicalFK=10, Character="Angelica Schuyler" },
                new CastMusical {CastFK=82, MusicalFK=10, Character="Thomas Jefferson" },
                new CastMusical {CastFK=83, MusicalFK=10, Character="George Washington" },
                new CastMusical {CastFK=84, MusicalFK=10, Character="King George" },
                new CastMusical {CastFK=85, MusicalFK=10, Character="Philip Hamilton" },
                new CastMusical {CastFK=86, MusicalFK=10, Character="Peggy Schuyler" }
            };
                CastMusical.ForEach(cc => context.CastMusical.AddOrUpdate(c => c.Character, cc));
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var erros = ex.EntityValidationErrors
                        .SelectMany(e => e.ValidationErrors)
                        .Select(x => "Campo: " + x.PropertyName + " -> " + x.ErrorMessage);

                var mensagem = string.Join("\n", erros);

                throw new Exception(mensagem);

            }
        }
    }
}