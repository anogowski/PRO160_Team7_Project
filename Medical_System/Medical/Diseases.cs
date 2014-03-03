using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_System.Medical
{
    public class Diseases
    {
        Dictionary<string, string> Info = new Dictionary<string, string>();
        ObservableCollection<string> Name = new ObservableCollection<string>();
        public Diseases()
        {
            AutoFillMental();
        }

        private void AutoFillMental()
        {
            Name.Add("Acute stress disorder");
            Name.Add("Adjustment disorders");
            Name.Add("Agoraphobia");
            Name.Add("Alcohol and substance abuse");
            Name.Add("Alcohol and substance dependence");
            Name.Add("Amnesia");
            Name.Add("Anxiety disorders");
            Name.Add("Anorexia nervosa");
            Name.Add("Antisocial personality disorder");
            Name.Add("Asperger's syndrome");
            Name.Add("Attention deficit hyperactivity disorder");
            Name.Add("Akiltism");
            Name.Add("Autism");
            Name.Add("Avoidant personality disorder");
            Name.Add("Bibliomania");
            Name.Add("Binge eating disorder");
            Name.Add("Bipolar disorder");
            Name.Add("Bipolar I disorder");
            Name.Add("Bipolar II disorder");
            Name.Add("Body dysmorphic disorder");
            Name.Add("Borderline personality disorder");
            Name.Add("Brief psychotic disorder");
            Name.Add("Bruxism");
            Name.Add("Bulimia nervosa");
            Name.Add("Conduct disorder");
            Name.Add("Conversion disorder");
            Name.Add("Cyclothymia");
            Name.Add("Delusional disorder");
            Name.Add("Dependent personality disorder");
            Name.Add("Depersonalization disorder");
            Name.Add("Depressive personality disorder");
            Name.Add("Dermotillomania");
            Name.Add("Disorder of written expression");
            Name.Add("Dissocial personality disorder");
            Name.Add("Dissociative fugue");
            Name.Add("Dissociative identity disorder");
            Name.Add("Down syndrome");
            Name.Add("Dyslexia");
            Name.Add("Dyspareunia");
            Name.Add("Dysthymia");
            Name.Add("Encopresis");
            Name.Add("Enuresis (bedwetting)");
            Name.Add("Erotomania");
            Name.Add("Exhibitionism");
            Name.Add("Expressive language disorder");
            Name.Add("Female and male orgasmic disorders");
            Name.Add("Female sexual arousal disorder");
            Name.Add("Folie à deux");
            Name.Add("Frotteurism");
            Name.Add("Gambling addiction");
            Name.Add("Gender identity disorder");
            Name.Add("Generalized anxiety disorder");
            Name.Add("General adaptation syndrome");
            Name.Add("Histrionic personality disorder");
            Name.Add("Primary hypersomnia");
            Name.Add("Hypoactive sexual desire disorder");
            Name.Add("Hypochondriasis");
            Name.Add("Hypomania");
            Name.Add("Hyperkinetic syndrome");
            Name.Add("Hypersexuality");
            Name.Add("Hysteria");
            Name.Add("Intermittent explosive disorder");
            Name.Add("Joubert syndrome");
            Name.Add("Kleptomania");
            Name.Add("Major depressive disorder");
            Name.Add("Male erectile disorder");
            Name.Add("Mania");
            Name.Add("Mental retardation");
            Name.Add("Munchausen syndrome");
            Name.Add("Mathematics disorder");
            Name.Add("Minor depressive disorder");
            Name.Add("Narcissistic personality disorder");
            Name.Add("Narcolepsy");
            Name.Add("Nightmare disorder");
            Name.Add("Obsessive-compulsive disorder");
            Name.Add("Obsessive-compulsive personality disorder");
            Name.Add("Onychophagia");
            Name.Add("Oppositional defiant disorder");
            Name.Add("Pain disorder");
            Name.Add("Panic attacks");
            Name.Add("Panic disorder");
            Name.Add("Paranoid personality disorder");
            Name.Add("Passive-aggressive personality disorder");
            Name.Add("Pathological gambling");
            Name.Add("Pervasive developmental disorder");
            Name.Add("Pica");
            Name.Add("Post-traumatic stress disorder");
            Name.Add("Premature ejaculation");
            Name.Add("Primary insomnia");
            Name.Add("Psychotic disorder");
            Name.Add("Pyromania");
            Name.Add("Reading disorder");
            Name.Add("Retts disorder");
            Name.Add("Rumination syndrome");
            Name.Add("Sadistic personality disorder");
            Name.Add("Schizoaffective disorder");
            Name.Add("Schizoid personality disorder");
            Name.Add("Schizophrenia");
            Name.Add("Schizophreniform disorder");
            Name.Add("Schizotypal personality disorder");
            Name.Add("Seasonal affective disorder");
            Name.Add("Self-defeating personality disorder");
            Name.Add("Separation anxiety disorder");
            Name.Add("Shared psychotic disorder");
            Name.Add("Sleep disorder");
            Name.Add("Sleep terror disorder");
            Name.Add("Sleepwalking disorder");
            Name.Add("Social phobia");
            Name.Add("Somatization disorder");
            Name.Add("Specific phobias");
            Name.Add("Stereotypic movement disorder");
            Name.Add("Stuttering");
            Name.Add("Tourette syndrome");
            Name.Add("Transient tic disorder");
            Name.Add("Trichotillomania");
        }

        public ObservableCollection<string> getName()
        {
            return Name;
        }

        public void Populate(string toBeAdded)
        {
            Name.Add(toBeAdded);
        }



    }
}
