using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Script needs some optimization...

public class UIChatboxController : MonoBehaviour
{
    // adjust this later, after client hosting was implemented
    public string username = "Username";

    // "textObject" could be named better
    public GameObject chatpanel, textobject;
    public InputField playerInputField;
    public Color playerMessage, infoMessage, npcMessage;

    // maybe make it a queue? (Because first items are removed when limit is reached)
    [SerializeField]
    List<Message> chatbox = new List<Message>();
    public int chatboxLimit = 50;

    void Update() {
        if (playerInputField.text != "") {
            if (Input.GetKeyDown(KeyCode.Return)) {
                SendMessageToChat(username + ": " + playerInputField.text, Message.MessageType.playerMessage);
                playerInputField.text = "";
            }
        } else {
            if (!playerInputField.isFocused && Input.GetKeyDown(KeyCode.Return)) playerInputField.ActivateInputField();
        }
    }

    // make calls from outside easier
    void SendMessageToChat(string messageText, Message.MessageType messageType) {
        if (chatbox.Count >= chatboxLimit) {
            Destroy(chatbox[0].textObject.gameObject);
            chatbox.Remove(chatbox[0]);
        }

        // Use constructor here? (create first)
        Message newMessage = new Message();
        newMessage.text = messageText;
        GameObject newText = Instantiate(textobject, chatpanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();
        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = getMessageTypeColor(messageType);
        chatbox.Add(newMessage);
    }

    // adjust opacity in editor?
    Color getMessageTypeColor(Message.MessageType messageType) {
        Color color = playerMessage;

        switch (messageType) {
            case Message.MessageType.infoMessage:
                color = infoMessage;
                break;
            case Message.MessageType.npcMessage:
                color = npcMessage;
                break;
        }

        return color;
    }
}

// Serializable necessary?
[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    // more types?
    public enum MessageType {
        playerMessage,
        infoMessage,
        npcMessage
    }

    // make constructor?
}
